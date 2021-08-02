using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;

namespace Presentacion.Controllers
{
    public class ReservaController : Controller
    {        
        public ActionResult Listar()
        {
            try
            {
                List<N_Reserva> listareserva = N_Reserva.ListarReservas();
                return View(listareserva);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }        

        public ActionResult Agregar(int id)
        {
            try
            {
                N_Reserva reserva = new N_Reserva();
                reserva.id_Alumno = (int)Session["idAlumno"];
                reserva.id_Apuntes = id;
                return View(reserva);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Insertar(N_Reserva reservas)
        {
            try
            {
                reservas.id_Alumno = Convert.ToInt32(Request.Form["id_Alumno"]);
                reservas.id_Apuntes = Convert.ToInt32(Request.Form["id_Apuntes"]);
                reservas.Reserva = Convert.ToDouble(Request.Form["Reserva"]);
                reservas.Insertar();

                return RedirectToAction("Listar", "Reserva");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }        
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                N_Reserva reserva = N_Reserva.ListarReservas().Where(x => x.id_Reservas == id).FirstOrDefault();
                N_Reserva.Eliminar(id);
                return View("Listar", N_Reserva.ListarReservas());
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }
        public ActionResult Saldar(int id)
        {
            try
            {
                N_Reserva reserva = N_Reserva.ListarReservas().Where(x => x.id_Reservas == id).FirstOrDefault();
                N_Reserva.Saldar(id);
                return View("Listar", N_Reserva.ListarReservas());
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }
    }
}