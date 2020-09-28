using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Telefono
    {
        private string numero = "";
        private string compania = "";
        private string horario = "";
        private bool esPersonal = false;
        //
        public string Numero
        {
            get { return numero; }
        }

        public Telefono(string numero, string compania, string horario, bool esPersonal)
        {
            this.numero = numero;
            this.compania = FormatearCompania(compania);
            this.horario = horario;
            this.esPersonal = esPersonal;
        }
        //
        public override string ToString()
        {
            string respuesta = "\n";
            respuesta += "Numero: " + numero + "\n";
            respuesta += "Compania: " + compania + "\n";
            if (esPersonal)
            {
                respuesta += "Personal, solo usarlo en caso de emergencia";
            }
            else
            {
                respuesta += "Horario: " + horario + "\n";
            }
            return respuesta;
        }

        public static bool ValidarNumero(string numero)
        {   // todo: el numero empiece con 0        
            return numero.Length == 9;
        }

        public static bool ValidarCompania(string compania)
        {
            string nombre = FormatearCompania(compania);
            return nombre == "ANTEL" || nombre == "CLARO";
        }

        private static string FormatearCompania(string compania)
        {
            return compania.Trim().ToUpper();
        }

    }
}
