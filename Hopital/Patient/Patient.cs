using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Patient
    {
        private int id;
        private string nom;
        private string prenom;
        private int age;
        private string medecin;
        private Adresse adresse;
        private string telephone;

        public Patient(int id, string nom, string prenom, int age,string telephone, Adresse adresse)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;
            this.adresse = adresse;
            this.telephone = telephone;
        }
        public Patient(int id,string nom, string prenom, int age)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;
        }
        public Patient(int id, string nom, string prenom, int age, string telephone)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;
            this.telephone = telephone;
        }
        public Patient()
        {
          
           
        }
        public Patient(int id)
        {
            this.id = id;
            
        }
        public Patient( string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;

        }
        public Patient(int id,string nom, string prenom)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;

        }
        public Patient(int id, Adresse adresse, string telephone)
        {
            this.id = id;
            this.adresse = adresse;
            this.telephone = telephone;

        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom= value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { prenom= value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        public Adresse Adresse
        {
            get { return adresse; }
            set
            {
                adresse = value;
            }
        }
        public string Medecin
        {
            get { return medecin; }
            set { medecin = value; }
        }

       public void RecevoirMessage(int numeroSalle)
        {
            Console.WriteLine($"Patient {this.prenom} {this.nom}, vous etes attendu en salle {numeroSalle} .");
        }


        public override string ToString()
        {
            return "id : " + id  + "\t" + "nom : "   + nom + "\t" + " prenom : " + prenom + "\t"  + " age : " + age + "\t" + "\n ";
        }


    }
}
