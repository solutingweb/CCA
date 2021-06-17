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
    public class Usuario
    {

        public static DataTable ObtenerPorUsuario(string usuario, string password)
        {

            var DataTable = new DataTable();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
            {
                cn.Open();

                // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                SqlCommand cmd = new SqlCommand("Usuarios_ObtenerPorUsuario", cn);

                // 2. Especifico el tipo de Comando
                cmd.CommandType = CommandType.StoredProcedure;

                //// 3. Agrego el Valor al Procedimiento almacenado
                cmd.Parameters.Add(new SqlParameter("@Usuario", usuario));
                cmd.Parameters.Add(new SqlParameter("@Passwords", password));

                // Ejecuto el comando y asigo el valor al DataReader
                var dataReader = cmd.ExecuteReader();

                DataTable.Load(dataReader);
            }

            return DataTable;

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
                    SqlCommand cmd = new SqlCommand("Usuario_Listar", cn);

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
    }
}
