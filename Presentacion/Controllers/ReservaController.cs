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
        
        public ActionResult Index()
        {
            List<N_Reserva> listareserva = N_Reserva.ListarReservas();
            return View(listareserva);
        }        

        public ActionResult Agregar(int id)
        {
            N_Reserva reserva = new N_Reserva();
            reserva.id_Alumno = (int)Session["idAlumno"];
            reserva.id_Apuntes = id;           
            return View(reserva);
        }

        [HttpPost]
        public ActionResult Insertar(N_Reserva reservas)
        {

            reservas.id_Alumno = Convert.ToInt32(Request.Form["id_Alumno"]);
            reservas.id_Apuntes = Convert.ToInt32(Request.Form["id_Apuntes"]);
            reservas.Reserva = Convert.ToDouble(Request.Form["Reserva"]);           
            reservas.Insertar();

            return RedirectToAction("Index", "Reserva");           
        }

        public ActionResult Eliminar(int id)
        {
            N_Reserva reserva = N_Reserva.ListarReservas().Where(x => x.id_Reservas == id).FirstOrDefault();
            N_Reserva.Eliminar(id);            
            return View("Index", N_Reserva.ListarReservas());
        }
        public ActionResult Entregar(int id)
        {
            N_Reserva reserva = N_Reserva.ListarReservas().Where(x => x.id_Reservas == id).FirstOrDefault();
            N_Reserva.Entregar(id);
            //cliente.RegistrarBajaCliente();
            return View("Index", N_Reserva.ListarReservas());
        }
    }
}