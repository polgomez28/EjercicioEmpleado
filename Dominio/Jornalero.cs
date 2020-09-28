using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Jornalero : Empleado
    {
        private int jornal;

        public int Jornal
        {
            get { return jornal; }
            set { jornal = value; }
        }

        public Jornalero(int jornal, string cedula, string nombre, Cargo cargo) : base(cedula, nombre, cargo)
        {
            this.jornal = jornal;
        }

        public override string ToString()  // POLIMORFICOS
        {
            return base.ToString() + "jornalero\n Jornal:" + jornal ;
        }

    }
}
