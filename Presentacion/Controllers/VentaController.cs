using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;

namespace Presentacion.Controllers
{
    public class VentaController : Controller
    {
        public ActionResult Listar()
        {
            try
            {
                List<N_Venta> listaventas = N_Venta.Listar();
                return View(listaventas);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });

            }
        }
    }
}