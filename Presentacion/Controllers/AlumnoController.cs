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
        // GET: Alumno
        public ActionResult Listar()
        {
            List<N_Alumno> listaalumnos = N_Alumno.Listar();
            return View(listaalumnos);
        }
    }
}