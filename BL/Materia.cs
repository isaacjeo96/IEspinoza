using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        //QUERYS

        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
            {
                string query = "INSERT INTO [Materia]([Nombre],[Costo],[Descripcion])VALUES(@Nombre, @Costo, @Descripcion)";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = context;
                    cmd.CommandText = query;

                    SqlParameter[] collection = new SqlParameter[3];

                    collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[0].Value = materia.Nombre;

                    collection[1] = new SqlParameter("Costo", SqlDbType.Decimal);
                    collection[1].Value = materia.Costo;

                    collection[2] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                    collection[2].Value = materia.Descripcion;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Producto";
                    }
                }
            }

            return result;

        }
    }
}
