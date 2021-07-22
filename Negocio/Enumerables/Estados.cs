using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Enumerables
{
    public class Estados
    {
        public enum TipoEstado
        {
            Entregado = 1,
            Recibido = 0,        

        }

        /*Agregado Ariel Coronel - 18.06.2021*/
        public enum ListarApuntes
        {
            Activo = 0,
            Inactivo = 1,
        }
    }
}
