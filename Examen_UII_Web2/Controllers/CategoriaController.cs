using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Examen_UII_Web2.Models;

namespace Examen_UII_Web2.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        //Instanciar la clase Categoria
        private Categoria objCategoria = new Categoria();

        public ActionResult Index()
        {
            return View(objCategoria.Listar());
        }

        //Acction Visualizar

        public ActionResult Visualizar(int id)
        {
            return View(objCategoria.Obtener(id));
        }

        //Action Agregar Editar

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new Categoria() //agrega un nuevo objeto
                            : objCategoria.Obtener(id)
                );
        }

        //Action Guardar
        public ActionResult Guardar(Categoria objCategoria)
        {
            if (ModelState.IsValid)
            {
                objCategoria.Guardar();
                return Redirect("~/Categoria");
            }
            else
            {
                return View("~/Views/Categoria/AgregarEditar");
            }
        }

        //Action Eliminar

        public ActionResult Eliminar(int id)
        {
            objCategoria.categoria_id = id;
            objCategoria.Eliminar();
            return Redirect("~/Categoria");
        }
    }
}