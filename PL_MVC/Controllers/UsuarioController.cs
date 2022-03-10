using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Direccion direccion = new ML.Direccion();

            ML.Result result = BL.Direccion.GetAll();

            if (result.Correct)
            {
                direccion.Direcciones = result.Objects;
                return View(direccion);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }

        }// termina getall

        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            ML.Direccion direccion = new ML.Direccion();
            direccion.Usuario = new ML.Usuario();
            IdUsuario = (IdUsuario == null) ? 0 : direccion.Usuario.IdUsuario = IdUsuario.Value;

            ML.Result resultPaises = BL.Pais.GetAllEF();           
            direccion.Colonia = new ML.Colonia();
            direccion.Colonia.Municipio = new ML.Municipio();
            direccion.Colonia.Municipio.Estado = new ML.Estado();
            direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
            direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;

            if (IdUsuario <= 0)//si no se encuentra el id, va al formulario en vacio
            {
                return View(direccion);
            }
            else
            {
                direccion.Usuario.IdUsuario = IdUsuario.Value;
                ML.Result result = BL.Usuario.GetByIdEF(direccion.Usuario.IdUsuario);
                direccion.Usuario.IdUsuario = IdUsuario.Value;
                if (result.Correct)
                {
                    
                    direccion.Colonia = new ML.Colonia();
                    direccion.Colonia.Municipio = new ML.Municipio();
                    direccion.Colonia.Municipio.Estado = new ML.Estado();
                    direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                    direccion.Usuario = ((ML.Usuario)result.Object);

                    ML.Result resultEstados = BL.Estado.GetByIdPais(direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    ML.Result resultMunicipios = BL.Municipio.GetByIdEstado(direccion.Colonia.Municipio.Estado.IdEstado);
                    ML.Result resultColonias = BL.Colonia.GetByIdMunicipio(direccion.Colonia.IdColonia);

                    direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;
                    direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
                    direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
                    direccion.Colonia.Colonias = resultColonias.Objects;


                    return View(direccion);
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error " + result.ErrorMessage;
                }
                return PartialView();
            }
        }

       [HttpPost]
        public ActionResult Form(ML.Direccion direccion) //Add { Id null } //Update {Id > 0 }
        {
            ML.Result result = new ML.Result();

            if (direccion.Usuario.IdUsuario == 0)
            {
                result = BL.Usuario.AddEF(direccion.Usuario);
                if (result.Correct)
                {
                    ViewBag.Message = "Usuario agregado correctamente";
                }
            }
            else
            {
                result = BL.Usuario.UpdateEF(direccion.Usuario);
                if (result.Correct)
                {
                    ViewBag.Message = "Usuario actualizado correctamente";
                }
            }

            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente el usuario " + result.ErrorMessage;
            }

            return PartialView("ValidationModal");

        }


        public JsonResult GetEstado(byte IdPais)
        {
            var result = BL.Estado.GetByIdPais(IdPais);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.GetByIdEstado(IdEstado);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.GetByIdMunicipio(IdMunicipio);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
    }
}