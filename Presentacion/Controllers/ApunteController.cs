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
            List<N_Apunte> listadoApuntes = N_Apunte.ListarApuntes();

            return View(listadoApuntes);
        }

        public ActionResult ListarApuntes()
        {
            List<N_Apunte> listadoApuntes = N_Apunte.ListarApuntes();

            return View(listadoApuntes);
        }

        [HttpPost]
        public JsonResult GrabarCarrito()
        {
            Resultado resultado = new Resultado();
            
            N_CarroApuntes carritoGuardar = new N_CarroApuntes();
            
            List<N_CarroApuntes> listadoCarrito = new List<N_CarroApuntes>();
            
            listadoCarrito = (List<N_CarroApuntes>)Session["Apuntes"];
            
            try
            {
                foreach (var item in listadoCarrito)
                    carritoGuardar.Grabar(item.idApuntes,item.tituloApuntes,item.precioApuntes, DateTime.Now);
                
                resultado.EsCorrecto = true;
                
                resultado.Mensaje = "Venta Carrito OK";
                
                Session.Clear();
                
                return Json(resultado);
            }
            catch (Exception ex)
            {
                
                resultado.EsCorrecto = false;
                
                resultado.Mensaje = "ErrorGrabar: " + ex.Message;
                
                return Json(resultado);
            }
        }

        [HttpGet]
        public ActionResult AgregarCarrito(int? id)
        {
            int idApuntes = (int)id;

            N_CarroApuntes cargarCarrito = N_CarroApuntes.CarritoAp(idApuntes);
            
            List<N_CarroApuntes> listadoCarrito = new List<N_CarroApuntes>();

            if (Session["Apuntes"] != null)
                listadoCarrito = (List<N_CarroApuntes>)Session["Apuntes"];
            
            listadoCarrito.Add(cargarCarrito);
            
            Session["Apuntes"] = listadoCarrito;

            ViewBag.Carrito = "Apuntes en Carrito: " + listadoCarrito.Count() + " - Costo Acmulado: $" + cargarCarrito.totalCostoApuntes;

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