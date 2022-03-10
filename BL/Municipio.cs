using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result GetByIdEstado(int IdEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaEntities context = new DL_EF.IEspinozaEntities())
                {
                    var obj = context.MunicipioGetByIdEstado(IdEstado).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        ML.Municipio municipio = new ML.Municipio();
                        municipio.IdMunicipio = obj.IdMunicipio;
                        municipio.Nombre = obj.Nombre;
                        municipio.Estado = new ML.Estado();
                        municipio.Estado.IdEstado = obj.IdEstado.Value;

                        result.Object = municipio;

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
        }// GetByIdEstado
    }
}
