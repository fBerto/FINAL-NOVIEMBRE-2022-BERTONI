using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    internal class Cominucacion
    {
        public ZonaPaises ZonaPaises { get; set; }
        public double calcularPorcentajeDescuetno()
        {
            double porcentaje = 1;
            if (ZonaPaises == ZonaPaises.cuyo)
            {
                porcentaje = 0.15;
            }
            if (ZonaPaises == ZonaPaises.norte)
            {
                porcentaje = 0.10;
            }
            return porcentaje;
        }
    }
}
