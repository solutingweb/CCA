using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Negocio.Enumerables;

namespace Negocio
{
    //AGREGADO LUCHO
    public class N_Apunte
    {
        public int? id_Apuntes { get; set; }

        [Required(ErrorMessage = "Ingrese Titulo del Apunte [TituloApunte]")]
        public string tituloApunte { get; set; }

        [Required(ErrorMessage = "Ingrese Cantidad Copias [StockApuntes]")]
        public float Stock { get; set; }

        [Required(ErrorMessage = "Ingrese Cantidad de Hojas [CantidadHojas]")]
        public int cantidadHojas { get; set; }

        [Required(ErrorMessage = "Seleccione un Estado [Estado]")]
        public byte estado { get; set; }

        public float precio { set; get; }

        public Estados.ListarApuntes estadoApunte { set; get; }
        public Estados estadosApuntes { set; get; }

        #region Metodos Privados
        private static N_Apunte ArmarDatos(DataRow dr)
        {
            N_Apunte ventaApuntes = new N_Apunte();

            ventaApuntes.id_Apuntes = Convert.ToInt32(dr["id_Apuntes"]);
            ventaApuntes.tituloApunte = dr["tituloApunte"].ToString();
            ventaApuntes.Stock = Convert.ToInt32(dr["stock"]);
            ventaApuntes.cantidadHojas = Convert.ToInt32(dr["cantidadHojas"]);
            ventaApuntes.estado = Convert.ToByte(dr["estado"]);
            ventaApuntes.estadoApunte = (Estados.ListarApuntes)Convert.ToInt32(dr["estado"]);
            ventaApuntes.precio = Convert.ToInt64(dr["precio"]);

            return (ventaApuntes);
        }

        #endregion

        #region Metodos Publicos

        public static List<N_Apunte> ListarApuntes()
        {
            List<N_Apunte> listApuntes = new List<N_Apunte>();

            DataTable dt = Datos.Apunte.ListarApuntes();

            foreach (DataRow item in dt.Rows)
            {
                listApuntes.Add(ArmarDatos(item));
            }
            return listApuntes;
        }

        public static List<N_Apunte> ListarApuntesPorId(int idApuntes)
        {
            List<N_Apunte> apuntePorID = new List<N_Apunte>();
            DataTable dt = Datos.Apunte.ListarApuntesPorID(idApuntes);

            foreach (DataRow item in dt.Rows)
            {
                apuntePorID.Add(ArmarDatos(item));
            }
            return apuntePorID;
        }

        public void Grabar()
        {

        }

        #endregion

        public int InsertarApunte()
        {
            return Datos.Apunte.InsertarApunte(tituloApunte, Stock, cantidadHojas, estado);
        }
    }
}
