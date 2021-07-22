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
    public class ProfesorApunte
    {
        public static DataTable Lista_ProfesorApunte(int id)
        {

            var DataTable = new DataTable();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("ListaLibrosPorProfesor", cn);
                
                cmd.CommandType = CommandType.StoredProcedure;
              
                cmd.Parameters.Add(new SqlParameter("@Id", id));

                var dataReader = cmd.ExecuteReader();

                DataTable.Load(dataReader);
            }

            return DataTable;

        }
           
        public static int Insertar(int id_Profesor, string nombreApunte, byte estado, string digitalizado)
        {
            try
            {
                int id = 0;

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    DataTable dt = new DataTable();

                    cn.Open();

                    
                    SqlCommand cmd = new SqlCommand("Libro_Insertar", cn);

                    
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@id_Profesor", id_Profesor));
                    cmd.Parameters.Add(new SqlParameter("@nombreApunte", nombreApunte));
                    cmd.Parameters.Add(new SqlParameter("@estado", estado));
                    cmd.Parameters.Add(new SqlParameter("@digitalizado", digitalizado));

                    var dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                    id = Convert.ToInt32(dt.Rows[0][0]);
                }

                return id;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al Guardar el Libro: " + ex.Message);
            }
        }

        public static void Editar(int id_ProfesorApunter, int id_Profesor, string nombreApunte, byte estado, string digitalizado)
        {
            try
            {
                if (id_ProfesorApunter != 0)
                {
                    using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexión"].ConnectionString))
                    {
                        cn.Open();

                        
                        SqlCommand cmd = new SqlCommand("Libro_Editar", cn);
                        
                        cmd.CommandType = CommandType.StoredProcedure;

                        // 3. Agrego el Valor al Procedimiento almacenado
                        cmd.Parameters.Add(new SqlParameter("@id_ProfesorApunter", id_ProfesorApunter));
                        cmd.Parameters.Add(new SqlParameter("@Id_Profesor", id_Profesor));
                        cmd.Parameters.Add(new SqlParameter("@NombreApunte", nombreApunte));
                        cmd.Parameters.Add(new SqlParameter("@Estado", estado));
                        cmd.Parameters.Add(new SqlParameter("@Digitalizado", digitalizado));
                        
                        var dataReader = cmd.ExecuteReader();

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al Editar el Libro: " + ex.Message);
            }
        }
        
        public static DataTable Profesor_Obtener(int id)
        {

            var DataTable = new DataTable();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
            {
                cn.Open();

                
                SqlCommand cmd = new SqlCommand("Profesor_Obtener", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", id));

                var dataReader = cmd.ExecuteReader();

                DataTable.Load(dataReader);
            }

            return DataTable;

        }

        
        public static DataTable ListarNoDigitalizados()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("ListarProfesorApunteNOdigitalizado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dataReader = cmd.ExecuteReader();
                    dt.Load(dataReader);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("error ListarProfesorApunteNOdigitalizado" + ex.Message);
            }

        }
        public static int Digitalizar(int Id_ProfesorApunter)
        {
            try
            {
                int id = 0;
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("DigitalizarLibro", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id_ProfesorApunter", Id_ProfesorApunter));
                    var dataReader = cmd.ExecuteReader();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("error Digitalizar" + ex.Message);
            }

        }
        
    }
}

    
