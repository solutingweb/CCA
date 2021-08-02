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
        public ActionResult Listar()
        {
            try
            {
                List<N_Profesor> listaprofesor = N_Profesor.Listar();
                return View(listaprofesor);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }        
        public ActionResult AgregarLibro(int id)
        {
            try
            {
                Session["id"] = id;
                N_ProfesorApunte libro = new N_ProfesorApunte();
                libro.IdProfesor = (int)Session["id"];
                return View(libro);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }             

        [HttpPost]
        public ActionResult Insertar(N_ProfesorApunte libro)
        {
            try
            {
                libro.IdProfesor = Convert.ToInt32(Request.Form["IdProfesor"]);
                libro.NombreApunte = (Request.Form["NombreApunte"]);
                libro.TipoEstado = (Negocio.Enumerables.Estados.TipoEstado)Convert.ToInt32(Request.Form["Estado"]);
                libro.Digitalizado = "NO";
                libro.Grabar();

                return RedirectToAction("Listar", "Profesor");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }

        public ActionResult LibroProfesor(int id)
        {
            try
            {
                List<N_ProfesorApunte> listalibros = N_ProfesorApunte.ProfesorApunte(id);
                return View(listalibros);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            } 
        }
    }
}