using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Adresse
    {
        private int numero;
        private string cp;
        private string nomDeRue;

        public Adresse(int numero,string cp,string nomDeRue)
        {
            this.numero = numero;
            this.cp = cp;
            this.nomDeRue = nomDeRue;

        }
        public Adresse()
        {
           

        }

        public Adresse( string cp, string nomDeRue)
        {
           
            this.cp = cp;
            this.nomDeRue = nomDeRue;

        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Cp
        {
            get { return cp; }
            set { cp = value; }
        }
        public string NomDeRue
        {
            get { return nomDeRue; }
            set { nomDeRue = value; }
        }

        public override string ToString()
        {
            return numero + " " + nomDeRue + " " + cp;
        }
    }
}
