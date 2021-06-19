using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Admin()
        {
            List<N_Usuario> listaUsuario = N_Usuario.Listar();

            return View(listaUsuario);
        }
        public ActionResult EditarUsuario(int id)
        {
            N_Usuario usuario = N_Usuario.Listar().Where(x => x.IdUsuario == id).FirstOrDefault();
            return View(usuario);
        }

        public ActionResult AgregarUsuario()
        {
            N_Usuario usuario = new N_Usuario();
            return View(usuario);
        }

        [HttpPost]

        public ActionResult IngresarUsuario(N_Usuario usuarios)
        {
            usuarios.id_Rol = (int)usuarios.TipoPerfil;
            usuarios.Id_estado = (byte)usuarios.Estado;
            usuarios.InsertarUsuario();
            return RedirectToAction("Admin");
        }
        public ActionResult ModificarUsuario(N_Usuario usuarios)
        {
            usuarios.id_Rol = (int)usuarios.TipoPerfil;
            usuarios.Id_estado = (byte)usuarios.Estado;
            usuarios.ModificarUsuario();
            return RedirectToAction("Admin");
        }
    }
}