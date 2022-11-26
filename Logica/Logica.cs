using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logica
    {
        List<Cliente> clientes = new List<Cliente>();
        List<Agenda_Pagos> Agenda_Pagos = new List<Agenda_Pagos>();
        List<Entidad> entidades = new List<Entidad>();
        List<Provedor> provedores = new List<Provedor>();

        //EJERCICIO 1
        public void CargarActualzarCLiente(int dni, string nombre, string apellido, DateTime fechaNacimiento)
        {
            
//CORRECCIONES: Faltan los controles de obligatorios.
            int indice = clientes.FindIndex(x => x.dni == dni);
            Cliente cliente = new Cliente();
            cliente.dni = dni;
            cliente.nombre = nombre;
            cliente.apellido = apellido;
            cliente.fechaNaciemiento = fechaNacimiento;
            cliente.nivel = ObtenerNivel(dni);
            if (indice > 0)
            {
                
//CORRECCIONES: Si no te envian información (te envían vacios) pisas con nada los valores que tenias y los perdes. Lo correcto es obtener el cliente y editar ese cliente solo las propiedades que tienen valor.l
                clientes[indice] = cliente;
            }
            else
            {
                clientes.Add(cliente);
            }
        }

        public int ObtenerNivel(int dni)
        {
            int nivel = 0;
            
//CORRECCIONES: Si el usuario pago mas de una vez una entidad esto te trae repetidos.
            int cantidadEntidades = Agenda_Pagos.FindAll(x => x.dniUsuario == dni).Count();
            if (cantidadEntidades == 0)
            {
                nivel = 1;
            }
            if (cantidadEntidades > 0 && cantidadEntidades <= 3)
            {
                nivel = 2;
            }
            if (cantidadEntidades > 3)
            {
                nivel = 3;
            }
            return nivel;
        }

        //EJERCICIO 2
        public void CargaEntidades(string nombre, string descripcion, int codigoProvedor)
        {
            Entidad entidad = new Entidad();
            entidad.codigo = entidades.Count();
            entidad.nombre = nombre;
            entidad.descripcion = descripcion;
            entidad.codigoProvedor = codigoProvedor;
            entidades.Add(entidad);
        }

        //EJERCICIO 3
        public void CargaRegistro(int dni, int codigoEntidad, DateTime fechaPago, double monto)
        {
            Agenda_Pagos registro = new Agenda_Pagos();
            registro.dniUsuario = dni;
            registro.codigoEntidad = codigoEntidad;
            registro.fechaCreacion = DateTime.Now;
            registro.fechaPago = fechaPago;
            registro.montoPagar = monto;
            Agenda_Pagos.Add(registro);
            //CORRECCIONES: falta validar el nivel del usuario
        }

        //EJERCICIO 4
        public string Reporte(Paises pais)
        {
            //if (pais == Paises.brasil)
            //{
            //    List<Provedor> provedoresBrasil = provedores.FindAll(x => x.paisesDondeOpera == Paises.brasil);
            //}

//CORRECCIONES: Puede haber mas de un proveedor para un mismo pais y esto no funciona.
            Provedor provedor = provedores.Find(x => x.paisesDondeOpera == pais);

//CORRECCIONES: El enunciado pide hacer esto para todas las entidadesd el proveedor.
            Entidad entidad = entidades.Find(x => x.codigoProvedor == provedor.codigo);
            string resultado = "La entidad " + entidad.nombre + "esta gestonada por " + provedor.nombre + " y tiene " +
                provedor.clientesAsociados.Count.ToString() + "asociados a su agenda " + "la categoria es " + entidad.categoria;

            return resultado;
        }

        //EJERCICIO 5
        public void ActualizarRegistroPago(int dniUsuario, int nroEntidad, double dinero)
        {
            List<Agenda_Pagos> EntidadesFiltradas = Agenda_Pagos.FindAll(x => x.codigoEntidad == nroEntidad && x.dniUsuario == dniUsuario && x.fechaPago == null);
            
//CORRECCIONES: En ningun lado lo ordenas, no podes asegurarte que sea el último, ademas esto en ejecución no funciona, te daria index out of range
            Agenda_Pagos RegistroNoPago = EntidadesFiltradas[EntidadesFiltradas.Count()];
            RegistroNoPago.fechaPago = DateTime.Now;
            Entidad entidadPerteneceRegistro = entidades.Find(x => x.codigo == nroEntidad);


//CORRECCIONES: El evento no se guarda en ningun lado, ademas el proveedor debería agregar el evento a su listado y calcular el saldo.
            Evento evento = new Evento();
            evento.retiro = false;
            evento.fecha = DateTime.Now;
            evento.dniCliente = dniUsuario;
            evento.dinero = dinero;
            
            Cliente cliente = clientes.Find(x=>x.dni == dniUsuario);
            cliente.nivel = ObtenerNivel(dniUsuario);
        }
    }

}
