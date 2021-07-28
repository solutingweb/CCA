using System;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class N_Alumno
    {
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }    
        public int Dni { get; set; }
        public bool Estado { get; set; }
        public int Id_Carrera  { get; set; }


        #region metodo privado (por michel)
        private static N_Alumno ArmarDatos(DataRow dr)
        {
            N_Alumno Alumno = new N_Alumno();

            Alumno.IdAlumno = Convert.ToInt32(dr["Id_Alumno"]);
            Alumno.Nombre = dr["Nombre"].ToString();
            Alumno.Apellido = dr["Apellidos"].ToString();
            Alumno.Email = dr["Email"].ToString();
            Alumno.Edad = Convert.ToInt32(dr["edad"].ToString());
            Alumno.Estado = Convert.ToBoolean(dr["Estado"].ToString());
            Alumno.Dni = Convert.ToInt32(dr["dni"].ToString());
            Alumno.Id_Carrera = Convert.ToInt32(dr["Id_Carrera"].ToString());

            return Alumno;
        }  
        #endregion

        #region public
        public static List<N_Alumno> Listar()
        {
            List<N_Alumno> listaalumno = new List<N_Alumno>();

            DataTable dt = Datos.Alumno.Listar();

            foreach (DataRow item in dt.Rows)
            {
                listaalumno.Add(ArmarDatos(item));
            }
            return listaalumno;
        } 
        #endregion

    }
}
