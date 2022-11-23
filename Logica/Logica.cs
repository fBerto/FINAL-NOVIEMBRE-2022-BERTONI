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
            int indice = clientes.FindIndex(x => x.dni == dni);
            Cliente cliente = new Cliente();
            cliente.dni = dni;
            cliente.nombre = nombre;
            cliente.apellido = apellido;
            cliente.fechaNaciemiento = fechaNacimiento;
            cliente.nivel = ObtenerNivel(dni);
            if (indice > 0)
            {
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
        }

        //EJERCICIO 4
        public string Reporte(Paises pais)
        {
            //if (pais == Paises.brasil)
            //{
            //    List<Provedor> provedoresBrasil = provedores.FindAll(x => x.paisesDondeOpera == Paises.brasil);
            //}

            Provedor provedor = provedores.Find(x => x.paisesDondeOpera == pais);

            Entidad entidad = entidades.Find(x => x.codigoProvedor == provedor.codigo);
            string resultado = "La entidad " + entidad.nombre + "esta gestonada por " + provedor.nombre + " y tiene " +
                provedor.clientesAsociados.Count.ToString() + "asociados a su agenda " + "la categoria es " + entidad.categoria;

            return resultado;
        }

        //EJERCICIO 5
        public void ActualizarRegistroPago(int dniUsuario, int nroEntidad, double dinero)
        {
            List<Agenda_Pagos> EntidadesFiltradas = Agenda_Pagos.FindAll(x => x.codigoEntidad == nroEntidad && x.dniUsuario == dniUsuario && x.fechaPago == null);
            Agenda_Pagos RegistroNoPago = EntidadesFiltradas[EntidadesFiltradas.Count()];
            RegistroNoPago.fechaPago = DateTime.Now;
            Entidad entidadPerteneceRegistro = entidades.Find(x => x.codigo == nroEntidad);

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
