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
        
        public ActionResult Index()
        {
            List<N_ProfesorApunte> listaprofesorapunte = Negocio.N_ProfesorApunte.ListardeNoactualizados();
            return View(listaprofesorapunte);
        }
        public ActionResult AgregarApunte(int? id)
        {
            Session["id"] = id;
            N_Apunte apunte = new N_Apunte();
            return View(apunte);
        }
        public ActionResult InsertarApunte(N_Apunte apunte)
        {
            apunte.estado = 1;
            apunte.InsertarApunte();
            return RedirectToAction("Digitalizar");
        }
        public ActionResult Digitalizar(int? id)
        {
            id = (int?)Session["id"];
            N_ProfesorApunte profesorapunte = N_ProfesorApunte.ListardeNoactualizados().Where(x => x.IdProfesorApunte == id).FirstOrDefault();
            profesorapunte.Digitalizar(profesorapunte.IdProfesorApunte.Value);
            return View("Index", N_ProfesorApunte.ListardeNoactualizados());
        }


    }
}