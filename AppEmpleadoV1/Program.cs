
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEmpleadoV1
{
    class Program
    {
        static Empresa unaEmpresa = new Empresa();

        static void Main(string[] args)
        {
            int opcion;
            bool salir = false;
            while (salir == false)
            {
                MostrarMenu();
                opcion = PedirNumero();
                switch (opcion)
                {
                    case 1:
                        AltaEmpleado();
                        break;
                    case 2:
                        ListadoEmpleados();
                        break;
                    case 3:
                        ListadoCargos();
                        break;
                    case 4:
                        AgregarTelefono();
                        break;
                    case 0:
                        salir = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("************ Menu **********");
            Console.WriteLine("1-Ingresar un nuevo Empleado");
            Console.WriteLine("2-Consulta de empleados" );
            Console.WriteLine("3-Consulta de cargos");
            Console.WriteLine("4-Agregar Telefono");
            Console.WriteLine("0-Salir");
            Console.WriteLine();
        }

        private static string PedirTexto(string mensaje = "Ingrese el texto:")
        {
            Console.WriteLine(mensaje);
            string texto = Console.ReadLine();
            return texto;
        }

        private static int PedirNumero(string mensaje = "Ingrese el numero:")
        {
            int num;
            bool valido = false;
            do
            {
                Console.WriteLine(mensaje);
                valido = int.TryParse(Console.ReadLine(), out num);
                if (!valido)
                {
                    Console.WriteLine("Solo se admiten numeros");
                }
            } while (!valido);
            return num;
        }

        private static void AltaEmpleado()
        {
            string cedula;
            string nombre;
            int idCargo;
            Console.WriteLine("Alta de empleados");
            Console.WriteLine("-----------------");
            cedula = PedirTexto("Ingrese la cedula:");
            nombre = PedirTexto("Ingrese el nombre:");
            ListadoCargos();
            idCargo = PedirNumero("Ingrese identificador del cargo");            
            int tipo = PedirNumero("1-Mensual/2-jornalero");
            if (tipo == 1)
            {
                int sueldo = PedirNumero("Ingrese el sueldo:");
                if (unaEmpresa.AgregarEmpleadoMensual(sueldo, cedula, nombre, idCargo) == true)
                {
                    Console.WriteLine("-->Se ingreso correctamente");
                }
                else
                {
                    Console.WriteLine("-->No se puedo dar el alta, revise los datos.");
                }
            }
            else
            {
                int jornal = PedirNumero("Ingrese el jornal:");
                if (unaEmpresa.AgregarEmpleadoJornalero(jornal, cedula, nombre, idCargo) == true)
                {
                    Console.WriteLine("-->Se ingreso correctamente");
                }
                else
                {
                    Console.WriteLine("-->No se puedo dar el alta, revise los datos.");
                }
            }

        }

        private static void ListadoEmpleados()
        {
            Console.WriteLine("Consulta de empleados");
            Console.WriteLine("---------------------");
            foreach (Empleado unEmpleado in unaEmpresa.Empleados)
            {
                Console.WriteLine(unEmpleado);
            }
        }


        private static void ListadoCargos()
        {
            Console.WriteLine("Consulta de cargos");
            Console.WriteLine("------------------");
            foreach (Cargo unCargo in unaEmpresa.Cargos)
            {
                Console.WriteLine(unCargo);
            }
        }


        private static void AgregarTelefono()
        {

            string cedula="111";
            string numero="099111222";
            string compania = "Antel";
            string horario = "";
            bool esPersonal = true;

            // este metodo es el mas aconsejable
            if (unaEmpresa.AgregarTelefonoAlEmpleado(cedula, numero, compania, horario, esPersonal))
            {
                Console.WriteLine("-->Se ingreso correctamente");
            }
            else
            {
                Console.WriteLine("-->No se puedo dar el alta, revise los datos.");
            }


            // es otra opcion directo contra empleado
            //Empleado unEmpleado = unaEmpresa.ObtenerEmpleado(cedula);
            //if (unEmpleado != null)
            // {
            //    unEmpleado.AgregarTelefono(numero, compania, horario, esPersonal);
            //}
        }


    }
}

