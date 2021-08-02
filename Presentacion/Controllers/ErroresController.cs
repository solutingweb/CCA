using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class ErroresController : Controller
    {
        // GET: Error
        [ValidateInput(false)]
        [HttpGet]
        public ActionResult Error(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View(ViewBag);
        }        
    }
}