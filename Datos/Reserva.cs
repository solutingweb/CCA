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

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("AgregarReserva", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;


                    // 3. Agrego el Valor al Procedimiento almacenado
                    cmd.Parameters.Add(new SqlParameter("@ID_ALUMNO", id_Alumno));
                    cmd.Parameters.Add(new SqlParameter("@ID_APUNTES", id_Apuntes));
                    cmd.Parameters.Add(new SqlParameter("@RESERVA", reserva));
                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();
                    //dt.Load(dataReader);
                    //id = Convert.ToInt32(dt.Rows[0][0]);
                }

                return id;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar reserva: " + ex.Message);
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

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("ListarReservas", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener la lista de Usuarios: " + ex.Message);
            }

        }

        public static void Editar(int id_Reserva)
        {
            try
            {
                if (id_Reserva != 0)
                {
                    using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexión"].ConnectionString))
                    {
                        cn.Open();


                        SqlCommand cmd = new SqlCommand("EliminarReservas", cn);

                        cmd.CommandType = CommandType.StoredProcedure;

                        // 3. Agrego el Valor al Procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@id_Reservas", id_Reserva));

                        var dataReader = cmd.ExecuteReader();

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al eliminar la reserva: " + ex.Message);
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

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("EliminarReservas", cn);
                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. Agrego el Valor al Procedimiento almacenado      
                    cmd.Parameters.Add(new SqlParameter("@ID_RESERVAS", id_Reserva));

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la reserva" + ex.Message);
            }
        }
        public static int Entregar(int id_Reserva)
        {
            try
            {
                int id = 0;
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("EntregarReservas", cn);
                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. Agrego el Valor al Procedimiento almacenado      
                    cmd.Parameters.Add(new SqlParameter("@ID_RESERVAS", id_Reserva));

                    // Ejecuto el comando y asigo el valor al DataReader
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
