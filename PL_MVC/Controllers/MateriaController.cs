﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAll();
            ML.Materia materia = new ML.Materia();
            if (result.Correct)
            {
                materia.Materias = result.Objects.ToList();
                return View(materia);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al obtener la información" + result.ErrorMessage;
                return View();
            }
        }
    }
}