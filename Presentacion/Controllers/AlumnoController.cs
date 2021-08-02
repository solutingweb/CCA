using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;

namespace Presentacion.Controllers
{
    public class AlumnoController : Controller
    {     
        public ActionResult Listar()
        {
            try
            {
                List<N_Alumno> listaalumnos = N_Alumno.Listar();
                return View(listaalumnos);
            }
            catch (Exception ex)
            {    
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });   
                
            }
            
        }
    }
}