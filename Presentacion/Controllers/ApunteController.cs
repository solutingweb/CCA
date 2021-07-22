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
        // GET: Apuntes
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult QuitarCarrito(int? id)
        {
            List<N_CarroApuntes> quitarCarrito = (List<N_CarroApuntes>)Session["Apuntes"];
            
            var items = quitarCarrito.Find(c=>c.idApuntes==id);
            
            quitarCarrito.Remove(items);
            
            Session["Apuntes"] = quitarCarrito;

            return RedirectToAction("Index", "Apunte", null);
        }
    }
}