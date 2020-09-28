using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mensual : Empleado
    {
        private int sueldo;

        public int Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }
        }

        public Mensual(int sueldo, string cedula, string nombre, Cargo cargo) : base(cedula, nombre, cargo)
        {
            this.sueldo = sueldo;
        }

        public override string ToString() // POLIMORFICOS
        {
            return base.ToString() + "mensual\n, Sueldo:" + sueldo;
        }

    }
}
