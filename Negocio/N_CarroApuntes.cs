using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Transactions;
using System.Web;

namespace Negocio
{
    public class N_CarroApuntes
    {
        public int idApuntes { set; get; }
        public string tituloApuntes { set; get; }
        public float precioApuntes { set; get; }
        public float totalCostoApuntes { set; get; }
        public IEnumerable<DataRow> Rows { get; private set; }

        #region Metodos Privados

        private static bool Validar(string tituloApuntes,float precioApuntes, out string error)
        {
            error = "";
            if (string.IsNullOrEmpty(tituloApuntes))
                error = "Campo Titulo Apunte vacio";
            if (precioApuntes==0)
                error = "Campo Precio Apunte vacio";
            if (error == "")
                return true;
            else
                return false;
        }

        private static void Agregar(int idApunte, string tituloApuntes, float precioApuntes, DateTime fecha)
        {
            Datos.CarroApuntes.Agregar(idApunte,tituloApuntes, precioApuntes,fecha);
        }


        #endregion

        #region Metodos Publicos

        public static N_CarroApuntes CarritoAp(int? id)
        {
            int idApuntes = (int)id;
            N_CarroApuntes carritoApuntes = new N_CarroApuntes();

            DataTable dt = CarroApuntes.CarritoApuntesListar(idApuntes);

            foreach (DataRow item in dt.Rows)
            {
                carritoApuntes.idApuntes = (int)item["id_Apuntes"];
                carritoApuntes.tituloApuntes = item["tituloApunte"].ToString();
                carritoApuntes.precioApuntes = Convert.ToInt64(item["precio"]);
                carritoApuntes.totalCostoApuntes = carritoApuntes.totalCostoApuntes + carritoApuntes.precioApuntes;

            }
            return carritoApuntes;
        }

        public void Grabar(int idApunte, string tituloApuntes, float precioApuntes, DateTime fecha)
        {
            if (Validar(tituloApuntes, precioApuntes, out string error))
            {
                using (TransactionScope transacion = new TransactionScope())
                {
                    Agregar(idApunte, tituloApuntes, precioApuntes, fecha);
                    transacion.Complete();
                }
            }
        }

        #endregion
    }
}
