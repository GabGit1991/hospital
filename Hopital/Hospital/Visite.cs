using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    class Visite
    {
        private int id;
        private int idpatient;
        private DateTime date;
        private string medecin;
        private int tarif;
        private int numerosalle;


        public Visite(int id, int idpatient, DateTime date, string medecin, int tarif, int numerosalle)
        {

            this.idpatient = idpatient;
            this.medecin = medecin;
            this.tarif = tarif;
            this.date = DateTime.Now;
            this.numerosalle = numerosalle;
        }
        public Visite(int idpatient, DateTime date, string medecin, int tarif, int numerosalle)
        {

            this.idpatient = idpatient;
            this.medecin = medecin;
            this.tarif = tarif;
            this.date = DateTime.Now;
            this.numerosalle = numerosalle;
        }
        public Visite(int idpatient,  string medecin, int tarif, int numerosalle)
        {

            this.idpatient = idpatient;
            this.medecin = medecin;
            this.tarif = tarif;
            this.date = DateTime.Now;
            this.numerosalle = numerosalle;
        }
        public Visite(int id, int idpatient, string medecin, int tarif, int numerosalle)
        {

            this.idpatient = idpatient;
            this.medecin = medecin;
            this.tarif = tarif;
            this.date = DateTime.Now;
            this.numerosalle = numerosalle;
        }
        public Visite()
        {

        
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public int Idpatient
        {
            get
            {
                return idpatient;
            }
            set
            {
                idpatient = value;
            }
        }

        public string Medecin
        {
            get
            {
                return medecin;
            }
            set
            {
                medecin= value;
            }
        }

        public int Tarif
        {
            get
            {
                return tarif;
            }
            set
            {
                tarif = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        public int Numerosalle
        {
            get
            {
                return numerosalle;
            }
            set
            {
                numerosalle = value;
            }
        }

      

        public override string ToString()
        {
            return idpatient + " " + medecin + " " + tarif + " " + date + " " + numerosalle + " ";
        }
    }
}
