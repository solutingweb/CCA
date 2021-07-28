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

        float valorFinal;
             
      
        //public ActionResult ListarApunte()
        //{
        //    List<N_Apunte> listaapuntes = N_Apunte.Listar();
        //    return View(listaapuntes);
        //}


        public ActionResult Listar(int? id)
        {
            if (id != null)
            {
                Session["idAlumno"] = id;
                N_Alumno alumno = N_Alumno.Listar().Where(x => x.IdAlumno == id).FirstOrDefault();
                Session["NombreAlumno"] = alumno.Nombre;
            }
            else
            {
                Session["idAlumno"] = null;
                Session["NombreAlumno"] = null;
            }
            List<N_Apunte> listaapuntes = N_Apunte.Listar();
            return View(listaapuntes);
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
                    carritoGuardar.Grabar(item.idApuntes, item.tituloApuntes, item.precioApuntes, DateTime.Now);
                resultado.EsCorrecto = true;
                resultado.Mensaje = "Venta Carrito OK";
                Session["Apuntes"] = null;
                Session["AcumuladoCarrito"] = null;
                return Json(resultado);
            }
            catch (Exception ex)
            {
                resultado.EsCorrecto = false;
                resultado.Mensaje = "ErrorGrabar: " + ex.Message;
                Session["AcumuladoCarrito"] = null;
                Session["Apuntes"] = null;
                return Json(resultado);
            }
        }

        [HttpGet]
        public ActionResult AgregarCarrito(int? id)
        {

            if (id != null)
            {
                int idApuntes = (int)id;

                N_CarroApuntes cargarCarrito = N_CarroApuntes.CarritoAp(idApuntes);
                List<N_CarroApuntes> listadoCarrito = new List<N_CarroApuntes>();

                if (Session["Apuntes"] != null)
                    listadoCarrito = (List<N_CarroApuntes>)Session["Apuntes"];
                listadoCarrito.Add(cargarCarrito);
                Session["Apuntes"] = listadoCarrito;
                if (Session["AcumuladoCarrito"] != null)
                    valorFinal = (float)Session["AcumuladoCarrito"];
                valorFinal += cargarCarrito.totalCostoApuntes;
                Session["AcumuladoCarrito"] = valorFinal;

                return View();
            }
            else
            {
                ViewBag.mensaje = Session["AcumuladoCarrito"];
                return View();
            }
        }

        public ActionResult QuitarCarrito(int? id)
        {
            List<N_CarroApuntes> quitarCarrito = (List<N_CarroApuntes>)Session["Apuntes"];
            var removerID = quitarCarrito.Find(c => c.idApuntes == id);
            quitarCarrito.Remove(removerID);
            Session["Apuntes"] = quitarCarrito;
            Session["AcumuladoCarrito"] = (float)Session["AcumuladoCarrito"] - (float)removerID.precioApuntes;
            return RedirectToAction("AgregarCarrito", "Apunte", null);
        }

        [HttpPost]
        public JsonResult VaciarCarrito()
        {
            Resultado resultado = new Resultado();
            List<N_CarroApuntes> listadoCarrito = new List<N_CarroApuntes>();
            listadoCarrito = (List<N_CarroApuntes>)Session["Apuntes"];
            try
            {
                if (listadoCarrito == null)
                {
                    resultado.EsCorrecto = false;
                    resultado.Mensaje = "Estaba_Vacio";
                    Session["AcumuladoCarrito"] = null;
                    return Json(resultado);
                }
                else
                {
                    resultado.EsCorrecto = true;
                    resultado.Mensaje = "Vacio_OK";
                    Session["Apuntes"] = null;
                    Session["AcumuladoCarrito"] = null;
                    return Json(resultado);
                }
            }
            catch (Exception ex)
            {
                resultado.EsCorrecto = false;
                resultado.Mensaje = "ErrorGrabar: " + ex.Message;
                return Json(resultado);
            }
        }

    }
}