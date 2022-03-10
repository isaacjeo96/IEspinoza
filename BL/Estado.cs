using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetByIdPais(byte IdPais)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaEntities context = new DL_EF.IEspinozaEntities())
                {
                    var obj = context.EstadoGetByIdPais(IdPais).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        ML.Estado estado = new ML.Estado();
                        estado.IdEstado = obj.IdEstado;
                        estado.Nombre = obj.Nombre;
                        estado.Pais = new ML.Pais();
                        estado.Pais.IdPais = obj.IdPais.Value;

                        result.Object = estado;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }// GetByIdPais
    }
}
