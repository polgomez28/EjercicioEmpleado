using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empresa
    {
        private List<Cargo> cargos = new List<Cargo>();
        private List<Empleado> empleados = new List<Empleado>();
        //
        public List<Cargo> Cargos
        {
            get { return cargos; }
        }
        public List<Empleado> Empleados
        {
            get { return empleados; }
        }
        //
        public Empresa()
        {
            PrecargaCargos();
            PrecargaEmpleados();
        }
        //
        private void PrecargaCargos()
        {
            AgregarCargo("programador");
            AgregarCargo("analista");
            AgregarCargo("analista");
            AgregarCargo("lider");

        }
        private void PrecargaEmpleados()
        {
            AgregarEmpleadoJornalero(1000,"111", "Ana", 1);
            AgregarEmpleadoMensual(50000,"222", "Juan", 2);
            AgregarEmpleadoJornalero(2000,"222", "Ana", 0); // falta porque se repite la cedula
            AgregarEmpleadoMensual(45000,"444", "Ana", 0);
            AgregarEmpleadoJornalero(3000,"555", "Ana", 1);
            AgregarEmpleadoMensual(60000, "666", "Ana", 1);
        }

        public bool AgregarCargo(string nombre)
        {
            bool exito = false;
            if (ObtenerCargo(nombre) == null)
            {
                Cargo unC = new Cargo(nombre);
                cargos.Add(unC);
                exito = true;
            }
            return exito;
        }

        private Cargo ObtenerCargo(string nombre)
        {
            int i = 0;
            Cargo cargo = null;
            while (cargo == null && i < cargos.Count)
            {
                if (cargos[i].Nombre == nombre)
                {                   
                    cargo = cargos[i];
                }
                i++;
            }
            return cargo;
        }

        public Cargo ObtenerCargo(int id)
        {
            int i = 0;
            Cargo cargo = null;
            while (cargo == null && i < cargos.Count)
            {
                if (cargos[i].Id == id)
                {
                    cargo = cargos[i];
                }
                i++;
            }
            return cargo;
        }


        public bool AgregarEmpleadoJornalero(int jornal, string cedula, string nombre, int idCargo)
        {
            bool exito = false;
            Cargo cargo = ObtenerCargo(idCargo);
            if (cargo != null)
            {
                if (ObtenerEmpleado(cedula) == null)
                {
                    Jornalero unE = new Jornalero(jornal, cedula, nombre, cargo);
                    empleados.Add(unE);
                    exito = true;
                }
            }
            return exito;
        }

        public bool AgregarEmpleadoMensual(int sueldo, string cedula, string nombre, int idCargo)
        {
            bool exito = false;
            Cargo cargo = ObtenerCargo(idCargo);
            if (cargo != null)
            {
                if (ObtenerEmpleado(cedula) == null)
                {
                    Mensual unE = new Mensual(sueldo, cedula, nombre, cargo);
                    empleados.Add(unE);
                    exito = true;
                }
            }
            return exito;
        }


        public Empleado ObtenerEmpleado(string cedula)
        {
            int i = 0;
            Empleado empleado = null;
            while (empleado == null && i < empleados.Count)
            {
                if (empleados[i].Cedula == cedula)
                {
                    empleado  = empleados[i];
                }
                i++;
            }
            return empleado;
        }

        public bool AgregarTelefonoAlEmpleado(string cedula, string numero, string compania, string horario, bool esPersonal)
        {
            bool exito = false;
            Empleado unEmpleado = ObtenerEmpleado(cedula);
            if (unEmpleado != null)
            {
                if (unEmpleado.AgregarTelefono(numero, compania, horario, esPersonal))
                {
                    exito = true;
                }

            }
            return exito;
        }

    }
}
