using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public class CarroApuntes
    {
       
        public static DataTable CarritoApuntesListar(int idApuntes)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("Carrito_Apuntes_Listar", cn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idApuntes", idApuntes));

                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener la lista de Apuntes por IdApuntes: " + ex.Message);
            }

        }

        public static void Agregar(int idApunte, string tituloApuntes, float precioApuntes, DateTime fecha)
        {
            try
            {
                #region Conexion SQL a la base de datos

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("Carrito_Apuntes_Guardar", cn);
                    
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@tituloApuntes", tituloApuntes));
                    cmd.Parameters.Add(new SqlParameter("@precioApuntes", precioApuntes));
                    cmd.Parameters.Add(new SqlParameter("@fecha", fecha));
                    cmd.Parameters.Add(new SqlParameter("@idApuntes", idApunte));

                    var dataReader = cmd.ExecuteReader();
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar registros en la Tabla VentasCarrito " + ex.Message);
            }
        }
    }
}
