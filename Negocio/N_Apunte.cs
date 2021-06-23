using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    
    public class N_Apunte
    {
        public int? id_Apuntes { get; set; }
        public string tituloApunte { get; set; }
        public byte id_estado { get; set; }
        public float Stock { get; set; }
        public int cantidadHojas { get; set; }
        public byte estado { get; set; }

        public int InsertarApunte()
        {
            return Datos.Apunte.InsertarApunte(tituloApunte, id_estado, Stock, cantidadHojas, estado);
        }

        public static List<N_Apunte> Listar()
        {
            List<N_Apunte> listaapuntes = new List<N_Apunte>();

            DataTable dt = Datos.Apunte.Listar();

            foreach (DataRow item in dt.Rows)
            {
                listaapuntes.Add(ArmarDatos(item));
            }
            return listaapuntes;
        }

        private static N_Apunte ArmarDatos(DataRow dr)
        {
            N_Apunte apunte = new N_Apunte();

            apunte.id_Apuntes = Convert.ToInt32(dr["id_Apuntes"]);
            apunte.id_estado = Convert.ToByte(dr["id_estado"]);
            apunte.tituloApunte = dr["tituloApunte"].ToString();
            apunte.Stock = Convert.ToInt16(dr["Stock"]);
            apunte.cantidadHojas = Convert.ToInt32(dr["cantidadHojas"]);
            apunte.estado = Convert.ToByte(dr["estado"]);

            return apunte;
        }
    }
}
