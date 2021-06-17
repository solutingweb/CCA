using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }       

        [HttpPost]
        public JsonResult Inicio()
        {
            Resultado resultado = new Resultado();

            try
            {
                Session["Usuario"] = N_Usuario.ObtenerPorUsuario(Request.Form["Usuario"].ToString(), Request.Form["Password"].ToString());

                resultado.EsCorrecto = true;
                resultado.Mensaje = "";

                return Json(resultado);

            }
            catch (Exception ex)
            {
                resultado.EsCorrecto = false;
                resultado.Mensaje = ex.Message;

                return Json(resultado);
            }

        }


        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }
    }
}