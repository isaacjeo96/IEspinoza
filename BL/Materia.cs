﻿using System;
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //query
                    string query = "MateriaGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;//utilizar Stored Procedure

                        DataTable materiaTable = new DataTable();//instnacia de mi DataTable

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(materiaTable);

                        if (materiaTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in materiaTable.Rows)
                            {
                                ML.Materia materia = new ML.Materia();

                                materia.IdMateria = int.Parse(row[0].ToString());
                                materia.Nombre = row[1].ToString();
                                materia.Costo = decimal.Parse(row[2].ToString());
                               // materia.Creditos = byte.Parse(row[3].ToString());
                                materia.Descripcion = row[3].ToString();
                               // materia.Semestre = new ML.Semestre();
                               // materia.Semestre.IdSemestre = byte.Parse(row[5].ToString());

                                result.Objects.Add(materia);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al seleccionar los registros en la tabla Producto";
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

    }

}
