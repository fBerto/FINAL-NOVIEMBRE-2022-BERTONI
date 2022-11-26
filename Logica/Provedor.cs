using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    
//CORRECCIONES: El proveedor no es una persona.
    internal class Provedor : Persona
    {
        public int codigo { get; set; }
        public double saldo { get; set; }
        public Paises paisesDondeOpera { get; set; }
        public List<Cliente> clientesAsociados { get; set; }
        public List<Evento> eventos { get; set; }
        
    }
}
