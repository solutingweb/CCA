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
        public enum EstadoReserva
        {
            Saldado = 1,
            Reservado = 0,

        }
        public enum TipoPerfil
        {
            Administrador = 0,
            Usuario = 1,
        }
        //Ver para sacar
        public enum Estado
        {
            Habilitado = 1,
            Deshabilitado = 0,
        }        
        public enum ListarApuntes
        {
            Activo = 0,
            Inactivo = 1,
        }
    }
}

