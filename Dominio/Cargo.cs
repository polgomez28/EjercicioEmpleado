using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cargo
    {
        private int id = 0;
        private string nombre = "";
        private static int ultId = 0;
        //
        public int Id
        {
            get { return id; }
        }
      
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        //
        public Cargo(string nombre)
        {
            this.id = ++ultId;
            this.nombre = nombre;
        }
        //
        public override string ToString()
        {
            return id + " - " + nombre;
        }
    }
}
