using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;

namespace Presentacion.Controllers
{
    public class ProfesorController : Controller
    {
        
        public ActionResult Index()
        {
            List<N_Profesor> listaprofesor = N_Profesor.Listar();
            return View(listaprofesor);
        }
        
        public ActionResult AgregarLibro(int id)
        {
            Session["id"] = id;
            N_ProfesorApunte libro = new N_ProfesorApunte();
            libro.IdProfesor = (int)Session["id"];
            return View(libro);
        }       
      

        [HttpPost]
        public ActionResult Insertar(N_ProfesorApunte libro)
        {       
            
            libro.IdProfesor = Convert.ToInt32(Request.Form["IdProfesor"]);
            libro.NombreApunte = (Request.Form["NombreApunte"]);
            libro.TipoEstado = (Negocio.Enumerables.Estados.TipoEstado)Convert.ToInt32(Request.Form["Estado"]);           
            libro.Digitalizado= (Request.Form["Digitalizado"]);
            libro.Grabar();           
            
            return RedirectToAction("Index", "Profesor");

        }

        public ActionResult LibroProfesor(int id)
        {           
            List<N_ProfesorApunte> listalibros = N_ProfesorApunte.ProfesorApunte(id);           
            return View(listalibros);            
        }

    }
}