using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    
//CORRECCIONES: En este caso no necesitamos esta clase.
    internal class Cliente : Persona
    {
        public DateTime fechaNaciemiento { get; set; }
        public int nivel { get; set; }
    }
}
