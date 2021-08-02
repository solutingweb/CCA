using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Negocio.Enumerables.Estados;

namespace Negocio
{
    public class N_Reserva
    {
        public int? id_Reservas { get; set; }
        public int id_Alumno { get; set; }
        public int id_Apuntes { get; set; }
        public double Reserva { get; set; }
        public DateTime Fecha { get; set; }
        public byte Estado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Apunte { get; set; }
        public int dni { get; set; }
        public Negocio.Enumerables.Estados.EstadoReserva TipoEstado { get; set; }


        #region MetodosPublicos        
        public static List<N_Reserva> ListarReservas()
        {
            List<N_Reserva> listareservas = new List<N_Reserva>();
            DataTable dt = Datos.Reserva.Listar();
            foreach (DataRow item in dt.Rows)
            {
                listareservas.Add(ArmarDatosReserva(item));
            }
            return listareservas;
        }
        public void Insertar()
        {
            Datos.Reserva.Insertar(id_Alumno, id_Apuntes, Reserva);
        }
        public static void Eliminar(int id)
        {
            Datos.Reserva.Eliminar(id);
        }
        public static void Saldar(int id)
        {
            Datos.Reserva.Saldar(id);
        }
        #endregion

        #region MetodosPrivados
        private static N_Reserva ArmarDatosReserva(DataRow dr)
        {
            N_Reserva reserva = new N_Reserva();
            reserva.id_Reservas = Convert.ToInt32(dr["id_Reservas"]);
            reserva.Apunte = dr["Apunte"].ToString();
            reserva.Fecha = Convert.ToDateTime(dr["Fecha"]);
            reserva.Nombre = dr["Nombre"].ToString();
            reserva.Apellido = dr["apellidos"].ToString();
            reserva.dni = Convert.ToInt32(dr["dni"]);
            reserva.Reserva = Convert.ToDouble(dr["reserva"]);
            reserva.TipoEstado = (EstadoReserva)Convert.ToInt32(dr["saldado"]);
            return reserva;
        }
        #endregion

    }
}
