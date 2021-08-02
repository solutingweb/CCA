using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Reserva
    {
        #region MetodosPublicos
        public static int Insertar(int id_Alumno, int id_Apuntes, double reserva)
        {
            try
            {
                int id = 0;

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    DataTable dt = new DataTable();

                    cn.Open();
                    SqlCommand cmd = new SqlCommand("AgregarReserva", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID_ALUMNO", id_Alumno));
                    cmd.Parameters.Add(new SqlParameter("@ID_APUNTES", id_Apuntes));
                    cmd.Parameters.Add(new SqlParameter("@RESERVA", reserva));
                    
                    var dataReader = cmd.ExecuteReader();                    
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar una reserva: " + ex.Message);
            }
        }

        public static DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("ListarReservas", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de reservas: " + ex.Message);
            }

        }        

        public static int Eliminar(int id_Reserva)
        {
            try
            {
                int id = 0;
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("EliminarReservas", cn);                    
                    cmd.CommandType = CommandType.StoredProcedure;   
                    cmd.Parameters.Add(new SqlParameter("@ID_RESERVAS", id_Reserva));
                    var dataReader = cmd.ExecuteReader();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la reserva" + ex.Message);
            }
        }
        public static int Saldar(int id_Reserva)
        {
            try
            {
                int id = 0;
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SaldarReservas", cn);                    
                    cmd.CommandType = CommandType.StoredProcedure;   
                    cmd.Parameters.Add(new SqlParameter("@ID_RESERVAS", id_Reserva));
                    var dataReader = cmd.ExecuteReader();

                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al entregar la reserva" + ex.Message);
            }
        }
        #endregion
    }
}
