using System;
using System.Collections.Generic;
using System.Data;

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
       
     


        public N_Usuario()
        { }

        private static N_Usuario ArmarDatos(DataRow dr)
        {
            N_Usuario Usuario = new N_Usuario();

            Usuario.IdUsuario = Convert.ToInt32(dr["id_Usuario"]);
            Usuario.Apellido = dr["Apellido"].ToString();
            Usuario.Nombre = dr["Nombre"].ToString();
            Usuario.Telefono = dr["Telefono"].ToString();
            Usuario.Usuario = dr["Usuario"].ToString();           
            Usuario.Passwords = dr["Passwords"].ToString();          

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

       
               
    }
}
