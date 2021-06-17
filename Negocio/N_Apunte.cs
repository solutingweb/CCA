using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    //AGREGADO LUCHO
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
    }
}
