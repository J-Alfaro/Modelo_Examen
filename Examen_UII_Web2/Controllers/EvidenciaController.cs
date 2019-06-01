using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen_UII_Web2.Models;

namespace Examen_UII_Web2.Controllers
{
    public class EvidenciaController : Controller
    {
        //instanciar la clase
        private Evidencia objEvidencia = new Evidencia();
        private Semestre objSemestre = new Semestre();
        private Modelo objModelo = new Modelo();
        private Categoria objCategoria = new Categoria();
        // GET: Modelo
        public ActionResult Index()
        {
            return View(objEvidencia.Listar());
        }

        //accion visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objEvidencia.Obtener(id));
        }

        //acccion agregar editar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.semestre = objSemestre.Listar();
            ViewBag.modelo= objModelo.Listar();
            ViewBag.categoria = objCategoria.Listar();
            
            return View(
                id == 0 ? new Evidencia() // Agregar un nuevo objeto
                : objEvidencia.Obtener(id)
                );
        }

        //accion Guardar
        public ActionResult Guardar(Evidencia objEvidencia)
        {
            if (ModelState.IsValid)
            {
                objEvidencia.Guardar();
                return Redirect("~/Modelo");
            }
            else
            {
                return View("~/Views/Modelo/AgregarEditar.cshtml");
            }
        }

        //accion eleiminar
        public ActionResult Eliminar(int id)
        {
            objEvidencia.modelo_id = id;
            objEvidencia.Eliminar();
            return Redirect("~/Modelo");
        }
    }
}