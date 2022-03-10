using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result GetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaEntities context = new DL_EF.IEspinozaEntities())
                {
                    var obj = context.ColoniaGetByIdMunicipio(IdMunicipio).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        ML.Colonia colonia = new ML.Colonia();
                        colonia.IdColonia = obj.IdColonia;
                        colonia.Nombre = obj.Nombre;
                        colonia.CodigoPostal = obj.CodigoPostal;
                        colonia.Municipio = new ML.Municipio();
                        colonia.Municipio.IdMunicipio = obj.IdMunicipio.Value;

                        result.Object = colonia;

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
        }// GetByIdMunicipio
    }
}
