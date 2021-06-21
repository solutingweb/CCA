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
                    SqlCommand cmd = new SqlCommand("Usuarios_Listar", cn);

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

        public static int AgregarUsuario(string Apellido, string Nombre, string Telefono, string Usuario, string Passwords, int id_Rol, byte Id_estado)
        {

            try
            {
                int id = 0;

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    DataTable dt = new DataTable();

                    cn.Open
                    ();
                    SqlCommand cmd = new SqlCommand("AgregarUsuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@apellido", Apellido));
                    cmd.Parameters.Add(new SqlParameter("@nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@telefono", Telefono));
                    cmd.Parameters.Add(new SqlParameter("@usuario", Usuario));
                    cmd.Parameters.Add(new SqlParameter("@passwords", Passwords));
                    cmd.Parameters.Add(new SqlParameter("@Id_logeo", id_Rol));
                    cmd.Parameters.Add(new SqlParameter("@Estado", Id_estado));
                    var dataReader = cmd.ExecuteReader();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("error AgregarApunte" + ex.Message);
            }
        }

        public static int EditarUsuario(int IdUsuario, string Apellido, string Nombre, string Telefono, string Usuario, string Passwords, int id_Rol, byte Id_estado)
        {

            try
            {
                int id = 0;

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    DataTable dt = new DataTable();

                    cn.Open
                    ();
                    SqlCommand cmd = new SqlCommand("EditarUsuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_Usuario", IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@apellido", Apellido));
                    cmd.Parameters.Add(new SqlParameter("@nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@telefono", Telefono));
                    cmd.Parameters.Add(new SqlParameter("@usuario", Usuario));
                    cmd.Parameters.Add(new SqlParameter("@passwords", Passwords));
                    cmd.Parameters.Add(new SqlParameter("@Id_logeo", id_Rol));
                    cmd.Parameters.Add(new SqlParameter("@Estado", Id_estado));
                    var dataReader = cmd.ExecuteReader();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("error AgregarApunte" + ex.Message);
            }
        }

        public static DataTable BuscarEstado(int id)
        {

            var DataTable = new DataTable();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
            {
                cn.Open();
                
                SqlCommand cmd = new SqlCommand("BuscarEstado", cn);
                
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.Add(new SqlParameter("@id", id));                

                var dataReader = cmd.ExecuteReader();

                DataTable.Load(dataReader);
            }

            return DataTable;

        }
    }
}
