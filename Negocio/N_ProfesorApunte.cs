using System;
using System.Collections.Generic;
using System.Data;
using static Negocio.Enumerables.Estados;
using Datos;

namespace Negocio
{
    public class N_ProfesorApunte
    {
        public int ? IdProfesorApunte { get; set; }
        public int IdProfesor { get; set; }
        public string NombreApunte { get; set; }     
        public string Digitalizado { get; set; }   
        public byte Estado { get; set; }
        public Negocio.Enumerables.Estados.TipoEstado TipoEstado { get; set; }
 
       



        public N_ProfesorApunte()
        { }

        private static N_ProfesorApunte ArmarDatos(DataRow dr)
        {
            N_ProfesorApunte ProfesorApunte = new N_ProfesorApunte();

            ProfesorApunte.IdProfesorApunte = Convert.ToInt32(dr["id_ProfesorApunter"]);
            ProfesorApunte.IdProfesor = Convert.ToInt32(dr["id_Profesor"]);
            ProfesorApunte.NombreApunte = dr["nombreApunte"].ToString();
            ProfesorApunte.Estado = Convert.ToByte(dr["Estado"]);
            ProfesorApunte.TipoEstado = (TipoEstado)Convert.ToInt32(dr["Estado"]);
            ProfesorApunte.Digitalizado = dr["digitalizado"].ToString();           

            return ProfesorApunte;
        }
              
        public static List<N_ProfesorApunte> ProfesorApunte(int idProfesor)
        {
            List<N_ProfesorApunte> profesorapunte = new List<N_ProfesorApunte>();

            DataTable dt = Datos.ProfesorApunte.Lista_ProfesorApunte(idProfesor);

            foreach (DataRow item in dt.Rows)
            {
                profesorapunte.Add(ArmarDatos(item));
            }
            return profesorapunte;
        }

        
        public void Grabar()
        {
            if (Validar(out string error))
            {
                if (IdProfesorApunte != null)
                    Editar();
                else
                    Insertar();
            }
            else
                throw new Exception(error);
        }

        private void Editar()
        {
            Datos.ProfesorApunte.Editar(IdProfesorApunte.Value, IdProfesor, NombreApunte, Estado , Digitalizado);
        }

        public void Insertar()
        {
            Datos.ProfesorApunte.Insertar(IdProfesor, NombreApunte, Estado, Digitalizado);
        }

        private bool Validar(out string error)
        {
            error = "";
            var Valido = true;

            if (NombreApunte == "")
            {
                error = "El campo NombreApunte esta vacío";
                Valido = false;
            }            
            if (Digitalizado == "")
            {
                error += "El campo Digitalizado esta vacío";
                Valido = false;
            }

            return Valido;
        }
    }
}
