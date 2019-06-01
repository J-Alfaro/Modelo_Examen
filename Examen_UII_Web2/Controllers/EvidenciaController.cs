using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen_UII_Web2.Models;
using System.IO;

namespace Examen_UII_Web2.Controllers
{
    public class EvidenciaController : Controller
    {
        //instanciar la clase
        private Evidencia objEvidencia = new Evidencia();
        private Semestre objSemestre = new Semestre();
        private Modelo objModelo = new Modelo();
        private Categoria objCategoria = new Categoria();
        private Criterio objCriterio = new Criterio();
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
            ViewBag.criterio = objCriterio.Listar();


            return View(
                id == 0 ? new Evidencia() // Agregar un nuevo objeto
                : objEvidencia.Obtener(id)
                );
        }

        //accion Guardar
        public ActionResult Guardar(Evidencia objEvidencia, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    string archivo = (file.FileName).ToLower();

                    file.SaveAs(Server.MapPath("~/Imagenes/" + file.FileName));

                    objEvidencia.archivo = file.FileName;
                    objEvidencia.tamanio = Convert.ToString(Math.Round((Convert.ToDecimal(file.ContentLength) / (1024 * 1024)), 2)) + " Mb";
                    objEvidencia.tipo = Path.GetExtension(file.FileName);
                }
                objEvidencia.Guardar();
                return Redirect("~/Evidencia");
            }
            else
            {
                return View("~/Views/Evidencia/AgregarEditar.cshtml");
            }
        }

        //accion eleiminar
        public ActionResult Eliminar(int id)
        {
            objEvidencia.modelo_id = id;
            objEvidencia.Eliminar();
            return Redirect("~/Evidencia");
        }
    }
}