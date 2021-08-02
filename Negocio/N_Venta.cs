using System;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class N_Venta
    {
        
        public string tituloApuntes { get; set; }
        public float precioApuntes { get; set; }
        public DateTime fecha { get; set; }       


        #region metodos privados
        private static N_Venta ArmarDatos(DataRow dr)
        {
            N_Venta venta = new N_Venta();            
            venta.tituloApuntes = dr["TITULO_DEL_APUNTE"].ToString();
            venta.precioApuntes = Convert.ToInt64(dr["TOTAL_VENTAS"]);
            venta.fecha = Convert.ToDateTime(dr["FECHA"]);

            return venta;
        }
        #endregion

        #region metodos publicos
        public static List<N_Venta> Listar()
        {
            List<N_Venta> listaventas = new List<N_Venta>();

            DataTable dt = Datos.Venta.Listar();

            foreach (DataRow item in dt.Rows)
            {
                listaventas.Add(ArmarDatos(item));
            }
            return listaventas;
        } 
        #endregion

    }
}
