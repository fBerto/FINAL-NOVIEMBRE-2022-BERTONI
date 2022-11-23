using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    internal class Agenda_Pagos
    {
        public int dniUsuario { get; set; }
        public int codigoEntidad { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaPago { get; set; }
        public double montoPagar { get; set; }
    }
}
