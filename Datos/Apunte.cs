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
    //AGREGADO LUCHO
    public class Apunte
    {
        public static int InsertarApunte(string tituloApunte, byte id_estado, float Stock, int cantidadHojas, byte estado)
        {

            try
            {
                int id = 0;

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    DataTable dt = new DataTable();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("AgregarApunte", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@tituloApunte", tituloApunte));
                    cmd.Parameters.Add(new SqlParameter("@id_estado", id_estado));
                    cmd.Parameters.Add(new SqlParameter("@Stock", Stock));
                    cmd.Parameters.Add(new SqlParameter("@cantidadHojas", cantidadHojas));
                    cmd.Parameters.Add(new SqlParameter("@estado", estado));
                    var dataReader = cmd.ExecuteReader();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("error AgregarApunte" + ex.Message);
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
                    SqlCommand cmd = new SqlCommand("Apunte_Listar", cn);

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

                throw new Exception("Error al obtener la lista de apuntes: " + ex.Message);
            }

        }
    }
}
