using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Empleado
    {
        private string cedula = "";
        private string nombre = "";
        private Cargo cargo;
        private List<Telefono> telefonos = new List<Telefono>();

        public string Cedula
        {
            get { return cedula; }
        }

        public Empleado(string cedula, string nombre, Cargo cargo)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.cargo = cargo;
        }

        public override string ToString()
        {
            string respuesta = "";
            respuesta += "Cedula: " + cedula + "\n";
            respuesta += "Nombre: " + nombre + "\n";
            respuesta += "Cargo: " + cargo + "\n";
            for (int i = 0; i < telefonos.Count; i++)
            {
                respuesta += telefonos[i] + "\n";
            }
            return respuesta;
        }

        public void AsignarCargo(Cargo cargo)
        {
            this.cargo = cargo;
        }

        public bool AgregarTelefono(string numero, string compania, string horario, bool esPersonal)
        {

            bool exito = false;
            if (Telefono.ValidarNumero(numero) && Telefono.ValidarCompania(compania) && !ExisteTelefono(numero))
            {
                Telefono unT = new Telefono(numero, compania, horario, esPersonal);
                telefonos.Add(unT);
                exito = true;
            }
            return exito;
        }

        private bool ExisteTelefono(string numero)
        {
            int i = 0;
            bool encontre = false;
            while (!encontre && i < telefonos.Count)
            {
                if (telefonos[i].Numero == numero)
                {
                    encontre = true;
                }
                i++;
            }
            return encontre;
        }        

    }
}
