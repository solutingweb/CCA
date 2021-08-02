using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;

namespace Presentacion.Controllers
{
    public class EscaneoController : Controller
    {
        
        public ActionResult Listar()
        {
            try
            {
                List<N_ProfesorApunte> listaprofesorapunte = Negocio.N_ProfesorApunte.ListardeNoactualizados();
                return View(listaprofesorapunte);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }
        public ActionResult AgregarApunte(int? id)
        {
            try
            {
                Session["id"] = id;
                N_Apunte apunte = new N_Apunte();
                return View(apunte);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }
        public ActionResult InsertarApunte(N_Apunte apunte)
        {
            try
            {
                apunte.estado = 1;
                apunte.InsertarApunte();
                return RedirectToAction("Digitalizar");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }
        public ActionResult Digitalizar(int? id)
        {
            try
            {
                id = (int?)Session["id"];
                N_ProfesorApunte profesorapunte = N_ProfesorApunte.ListardeNoactualizados().Where(x => x.IdProfesorApunte == id).FirstOrDefault();
                profesorapunte.Digitalizar(profesorapunte.IdProfesorApunte.Value);
                return View("Listar", N_ProfesorApunte.ListardeNoactualizados());
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }


    }
}