using System;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class N_Profesor
    {
        public int IdProfesor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public Boolean Estado { get; set; }
        public string Dni { get; set; }
        public List<N_ProfesorApunte> ListaLibros { get; set; }



        #region Metodo privado
        private static N_Profesor ArmarDatos(DataRow dr)
        {
            N_Profesor Profesor = new N_Profesor();

            Profesor.IdProfesor = Convert.ToInt32(dr["id_Profesor"]);
            Profesor.Nombre = dr["Nombre"].ToString();
            Profesor.Apellido = dr["Apellidos"].ToString();
            Profesor.Email = dr["email"].ToString();
            Profesor.Estado = Convert.ToBoolean(dr["Estado"].ToString());
            Profesor.Dni = dr["DNI"].ToString();

            return Profesor;
        }
        #endregion



        #region Metodo publico
        public static List<N_Profesor> Listar()
        {
            List<N_Profesor> listaprofesores = new List<N_Profesor>();

            DataTable dt = Datos.Profesor.Listar();

            foreach (DataRow item in dt.Rows)
            {
                listaprofesores.Add(ArmarDatos(item));
            }
            return listaprofesores;
        } 
        #endregion

    }
}
