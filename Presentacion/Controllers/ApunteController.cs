using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;

namespace Presentacion.Controllers
{
    public class ApunteController : Controller
    {
        
        public ActionResult Index()
        {
            List<N_Apunte> listaapuntes = N_Apunte.Listar();
            return View(listaapuntes);
        }
    }
}