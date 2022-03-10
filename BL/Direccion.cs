using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Direccion
    {
        public static ML.Result DireccionGetByIdColonia(int IdColonia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaEntities context = new DL_EF.IEspinozaEntities())
                {
                    var query = context.DireccionGetByIdColonia(IdColonia).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Direccion direccion = new ML.Direccion();
                            direccion.IdDireccion = obj.IdDireccion;
                            direccion.Calle = obj.Calle;
                            direccion.NumeroExterior = obj.NumeroExterior;
                            direccion.NumeroInterior = obj.NumeroInterior;
                            direccion.Colonia = new ML.Colonia();
                            direccion.Colonia.IdColonia = obj.IdColonia.Value;

                            result.Objects.Add(direccion);

                        }
                        result.Correct = true;

                    }
                    else
                    {

                        result.Correct = false;
                        result.ErrorMessage = " No existen registros en la tabla Pais";
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaEntities context = new DL_EF.IEspinozaEntities())
                {

                    var lista = context.DireccionGetAll().ToList();

                    result.Objects = new List<object>();

                    if (lista != null)
                    {
                        foreach (var obj in lista)
                        {
                            ML.Direccion direccion = new ML.Direccion();

                            direccion.IdDireccion = obj.IdDireccion;
                            direccion.Calle = obj.Calle;
                            direccion.NumeroExterior = obj.NumeroExterior;
                            direccion.NumeroInterior = obj.NumeroInterior;

                            direccion.Colonia = new ML.Colonia();
                            direccion.Colonia.IdColonia = obj.IdColonia;
                            direccion.Colonia.Nombre = obj.Colonia;
                            direccion.Colonia.CodigoPostal = obj.CodigoPostal;

                            direccion.Colonia.Municipio = new ML.Municipio();
                            direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio;
                            direccion.Colonia.Municipio.Nombre = obj.Municipio;

                            direccion.Colonia.Municipio.Estado = new ML.Estado();
                            direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado;
                            direccion.Colonia.Municipio.Estado.Nombre = obj.Estado;

                            direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            direccion.Colonia.Municipio.Estado.Pais.IdPais = obj.IdPais;
                            direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.Pais;

                            direccion.Usuario = new ML.Usuario();
                            direccion.Usuario.IdUsuario = obj.IdUsuario;
                            direccion.Usuario.Nombre = obj.NombreUsuario;
                            direccion.Usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            direccion.Usuario.ApellidoMaterno = obj.ApellidoMaterno;

                            result.Objects.Add(direccion);
                        }

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
        }
        public static ML.Result GetByIdUsuario(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaEntities context = new DL_EF.IEspinozaEntities())
                {

                    var lista = context.DirecciongGetByIdUsuario(IdUsuario).ToList();

                    result.Objects = new List<object>();

                    if (lista != null)
                    {
                        foreach (var obj in lista)
                        {
                            ML.Direccion direccion = new ML.Direccion();

                            direccion.IdDireccion = obj.IdDireccion;
                            direccion.Calle = obj.Calle;
                            direccion.NumeroExterior = obj.NumeroExterior;
                            direccion.NumeroInterior = obj.NumeroInterior;

                            direccion.Colonia = new ML.Colonia();
                            direccion.Colonia.IdColonia = obj.IdColonia;
                            direccion.Colonia.Nombre = obj.Colonia;
                            direccion.Colonia.CodigoPostal = obj.CodigoPostal;

                            direccion.Colonia.Municipio = new ML.Municipio();
                            direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio;
                            direccion.Colonia.Municipio.Nombre = obj.Municipio;

                            direccion.Colonia.Municipio.Estado = new ML.Estado();
                            direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado;
                            direccion.Colonia.Municipio.Estado.Nombre = obj.Estado;

                            direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            direccion.Colonia.Municipio.Estado.Pais.IdPais = obj.IdPais;
                            direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.Pais;

                            direccion.Usuario = new ML.Usuario();
                            direccion.Usuario.IdUsuario = obj.IdUsuario;
                            direccion.Usuario.Nombre = obj.NombreUsuario;
                            direccion.Usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            direccion.Usuario.ApellidoMaterno = obj.ApellidoMaterno;

                            result.Objects.Add(direccion);
                        }

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
        }


    }
}
