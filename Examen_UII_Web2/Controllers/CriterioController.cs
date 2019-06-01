using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Examen_UII_Web2.Models;

namespace Examen_UII_Web2.Controllers
{
    public class CriterioController : Controller
    {
        // GET: Criterio
        private Criterio objCriterio = new Criterio();
        private Modelo objModelo = new Modelo();
       
        public ActionResult Index()
        {
            return View(objCriterio.Listar());
        }

        //accion visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objCriterio.Obtener(id));
        }

        //acccion agregar editar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Modelo = objModelo.Listar();
            return View(
                id == 0 ? new Criterio() // Agregar un nuevo objeto
                : objCriterio.Obtener(id)
                );
        }

        //accion Guardar
        public ActionResult Guardar(Criterio objCriterio)
        {
            if (ModelState.IsValid)
            {

                objCriterio.Guardar();

                return Redirect("~/Criterio");
            }
            else
            {
                return View("~/Views/Criterio/AgregarEditar.cshtml");
            }
        }

        //accion eliminar
        public ActionResult Eliminar(int id)
        {
            objCriterio.criterio_id = id;
            objCriterio.Eliminar();
            return Redirect("~/Criterio");
        }
    }
}