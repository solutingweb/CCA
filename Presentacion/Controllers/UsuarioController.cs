using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;

namespace Presentacion.Controllers
{
    public class UsuarioController : Controller
    {
        
        public ActionResult Listar()
        {
            return View();
        }

        public ActionResult Admin()
        {
            try
            {
                List<N_Usuario> listaUsuario = N_Usuario.Listar();
                return View(listaUsuario);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }
        public ActionResult EditarUsuario(int id)
        {
            try
            {
                N_Usuario usuario = N_Usuario.Listar().Where(x => x.IdUsuario == id).FirstOrDefault();
                return View(usuario);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }

        public ActionResult AgregarUsuario()
        {
            try
            {
                N_Usuario usuario = new N_Usuario();
                return View(usuario);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult IngresarUsuario(N_Usuario usuarios)
        {
            Resultado resultado = new Resultado();
            try
            {
                usuarios.id_Rol = (int)usuarios.TipoPerfil;
                usuarios.Id_estado = (byte)usuarios.Estado;
                N_Usuario.BuscarUsuario(usuarios.Usuario);
                N_Usuario.BuscarPassword(usuarios.Passwords);
                usuarios.InsertarUsuario();
                resultado.EsCorrecto = true;
                resultado.Mensaje = "";
                return RedirectToAction("Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }
        public ActionResult ModificarUsuario(N_Usuario usuarios)
        {
            Resultado resultado = new Resultado();
            try
            {
                usuarios.id_Rol = (int)usuarios.TipoPerfil;
                usuarios.Id_estado = (byte)usuarios.Estado;               
                usuarios.ModificarUsuario();
                resultado.EsCorrecto = true;
                resultado.Mensaje = "";
                return RedirectToAction("Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Errores", new { @mensaje = ex.Message });
            }
        }
    }
}