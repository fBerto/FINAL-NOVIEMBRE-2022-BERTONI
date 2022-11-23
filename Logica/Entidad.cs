using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    internal class Entidad
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime vencimientoPago { get; set; }
        public int codigoProvedor { get; set; }
        public string categoria { get; set; }

    }
}
