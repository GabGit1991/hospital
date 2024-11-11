using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Salle
    {
        private int numero;
        private Medecin medecin;
        private Patient patient;
        private bool occupe = false;
        private bool ouverte = true;

        public Salle()
        {

        }
        public Salle(int numero)
        {
            this.numero = numero;
        }
        public Salle(int numero, Medecin medecin,bool occupe,bool ouverte)
        {
           
            this.medecin = medecin;
            this.ouverte = ouverte;
            this.occupe = occupe;
        }

        public bool Occupe
        {
            get
            {
                return occupe;
            }
            set
            {
                occupe = value;
            }
        }
        public bool Ouverte
        {
            get
            {
                return ouverte;
            }
            set
            {
                ouverte = value;
            }
        }
        public int Numero
        {
            get
            {
                return numero;
            }
            set
            {
                numero = value;
            }
        }
        public Patient Patient
        {
            get { return patient; }
            set { patient = value; }
        }
        public Medecin Medecin
        {
            get
            {
                return medecin;
            }
            set
            {
                medecin = value;
            }
        }

        public override string ToString()
        {
            if (ouverte == true)
            {
                if (occupe == false)
                {
                    return "salle numero : " + numero + "libre medecin : " + medecin;
                }
                else
                {
                    return "salle numero : " + numero + "occupé medecin : " + medecin;
                }

            }
            else
            {
                return "salle numero : " + numero + "fermé";
            }

        }

    }
}
