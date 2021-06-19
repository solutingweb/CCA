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
        public enum TipoPerfil
        {
            Administrador = 0,
            Usuario = 1,
        }
        public enum Estado
        {
            Habilitado = 0,
            Deshabilitado = 1,
        }
    }
}
