using System;
using System.Collections.Generic;
using System.Data;
using static Negocio.Enumerables.Estados;

namespace Negocio
{
    public class N_Usuario
    {
        public int IdUsuario { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Usuario { get; set; }
        public string Passwords { get; set; }
        public int id_Rol { get; set; }
        public byte Id_estado { get; set; }
        public TipoPerfil TipoPerfil { get; set; }
        public Estado Estado { get; set; }



        private static N_Usuario ArmarDatos(DataRow dr)
        {
            N_Usuario Usuario = new N_Usuario();

            Usuario.IdUsuario = Convert.ToInt32(dr["id_Usuario"]);
            Usuario.Apellido = dr["Apellido"].ToString();
            Usuario.Nombre = dr["Nombre"].ToString();
            Usuario.Telefono = dr["Telefono"].ToString();
            Usuario.Usuario = dr["Usuario"].ToString();           
            Usuario.Passwords = dr["Passwords"].ToString();

            Usuario.id_Rol = Convert.ToInt32(dr["Id_logeo"]);
            Usuario.TipoPerfil = (TipoPerfil)Usuario.id_Rol;
            Usuario.Id_estado = Convert.ToByte(dr["Estado"]);
            Usuario.Estado = (Estado)Usuario.Id_estado;

            return Usuario;
        }


        public static N_Usuario ObtenerPorUsuario(string usuario, string password)
        {
            
            DataTable dt = Datos.Usuario.ObtenerPorUsuario(usuario, password);
            N_Usuario Usuario = new N_Usuario();
            if (dt.Rows.Count > 0)
            {
                return ArmarDatos(dt.Rows[0]);
            }
            else
            {
                throw new Exception("No existen Usuarios con los datos ingresados");
            }
            
            
        }

        //public static N_Usuario BuscarEstado(int id)
        //{
        //    DataTable dt = Datos.Usuario.BuscarEstado(id);
        //    N_Usuario Usuario = new N_Usuario();
        //    if (dt.Rows.Count > 0)
        //    {
        //        return ArmarDatos(dt.Rows[0]);
        //    }
        //    else
        //    {
        //        throw new Exception("No ......................");
        //    }
        //}
    }



        public static List<N_Usuario> Listar()
        {
            List<N_Usuario> listausuarios = new List<N_Usuario>();

            DataTable dt = Datos.Usuario.Listar();

            foreach (DataRow item in dt.Rows)
            {
                listausuarios.Add(ArmarDatos(item));
            }
            return listausuarios;
        }
        public int InsertarUsuario()
        {
            return Datos.Usuario.AgregarUsuario(Apellido, Nombre, Telefono, Usuario, Passwords, id_Rol, Id_estado);
        }
        public int ModificarUsuario()
        {
            return Datos.Usuario.EditarUsuario(IdUsuario, Apellido, Nombre, Telefono, Usuario, Passwords, id_Rol, Id_estado);
        }


    }
}
