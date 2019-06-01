using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen_UII_Web2.Models;


namespace Examen_UII_Web2.Controllers
{
    public class SemestreController : Controller
    {
        
    private Semestre objSemestre = new Semestre();

    public ActionResult Index()
    {
        return View(objSemestre.Listar());
    }

    //Acction Visualizar

    public ActionResult Visualizar(int id)
    {
        return View(objSemestre.Obtener(id));
    }

    //Action Agregar Editar

    public ActionResult AgregarEditar(int id = 0)
    {
        return View(id == 0 ? new Semestre() //agrega un nuevo objeto
                        : objSemestre.Obtener(id)
            );
    }

    //Action Guardar
    public ActionResult Guardar(Semestre objSemestre)
    {
        if (ModelState.IsValid)
        {
            objSemestre.Guardar();
            return Redirect("~/Semestre");
        }
        else
        {
            return View("~/Views/Semestre/AgregarEditar");
        }
    }

    //Action Eliminar

    public ActionResult Eliminar(int id)
    {
        objSemestre.semestre_id = id;
        objSemestre.Eliminar();
        return Redirect("~/Semestre");
    }
}
}