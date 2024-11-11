using Hospital;
using System;
using System.Collections.Generic;
using System.IO;


namespace Model
{
    abstract class User
    {
        protected string login;
        protected string password;
        protected string nom;
        protected Metier metier;

        protected Hopi hospi = Hopi.Instance;
        protected List<Patient> patients = new List<Patient>();
        protected Queue<Patient> fileAttente = Hopi.Instance.GetFildattente();
        protected MenuModule menuMod = new MenuModule();


        public User(string login, string password, string nom, Metier metier)
        {
            this.login = login;
            this.password = password;
            this.nom = nom;
            this.metier = metier;
        }
        public User(string nom, Metier metier)
        {
            this.nom = nom;
            this.metier = metier;
        }
        public User() { }
        public Metier Metier
        {
            get { return metier; }
            set { metier = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Login
        {
            get { return login; }
        }

        public string Password
        {
            get { return password; }
        }


        public override string ToString()
        {
            return "nom : " + nom + " metier : " + metier;
        }
    }

    class Secretaire : User
    {
        private const string LOG_FILE_PATH = @"C:\Users\gabri\Desktop\POEI Dev.NET_Mainframe\Code_Source\patients_log.txt";

        private DaoPatient daoPatient = new DaoPatient();
        private DaoVisite daoVisite = new DaoVisite();


        public Secretaire() : base() { }

        public Secretaire(string nom, Metier metier) : base(nom, metier) { }

        public Secretaire(string login, string password, string nom, Metier metier) : base(login, password, nom, metier) { }


        public void AjouterPatient()
        {
            menuMod.InfosPat(out int id, out string nom, out string prenom, out int age);
            Patient pToIn = new Patient(id, nom, prenom, age);

            if (daoPatient.EstEnregistre(pToIn.Id))
            {
                Console.WriteLine("Le patient est déjà connu dans le système. Il est ajouté à la file d'attente.");
            }
            else
            {
                Console.WriteLine("Le patient n'était pas connu dans le système.Il a été rajouté.");
                daoPatient.Insert(pToIn);

            }
            Hopi.Instance.AjouterPatFilDattente(pToIn);

            using (StreamWriter writer = File.AppendText(LOG_FILE_PATH))
            {
                writer.WriteLine($"{DateTime.Now} - Patient {pToIn.Nom} {pToIn.Prenom} est arrivé.");
            }

        }

        public void AffichageProchainPatient()
        {
            if (Hopi.Instance.GetFildattente().Count == 0)
            {
                Console.WriteLine("il n y a pas de prochain patient.");
                return;
            }
            Patient nextPatient = fileAttente.Peek();
            Console.WriteLine($"Patient Nom: {nextPatient.Nom}");
            Console.WriteLine($"Patient Prenom: {nextPatient.Prenom}");
            Console.WriteLine($"Patient Age: {nextPatient.Age}");

        }
        //ajouter telephone et adresse
        public void ModifierPatient()
        {
            Adresse adresse = new Adresse();
            Console.WriteLine("Entrer id du patient à modifier");
            int idup = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrer numero du batiment");
            adresse.Numero = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrer code postale");
            adresse.Cp = Console.ReadLine();
            Console.WriteLine("Entrer nom de la rue");
            adresse.NomDeRue = (Console.ReadLine());

            Console.WriteLine("Entrer numero de telephone");
            string telephone = Console.ReadLine();


            Patient pToUpAP = new Patient(idup, adresse, telephone);
            daoPatient.UpdatePhoneAdresse(pToUpAP);
        }
        public void AffichageVisPatId()
        {
            Console.WriteLine("entre id du patient");
            int idPatient = Int32.Parse(Console.ReadLine());
            List<Visite> livi = daoVisite.SelectByIdpatient(idPatient);
            foreach (Visite vis in livi)
            {
                Console.WriteLine(vis);
            }
        }

        public void AfficherFileAttente()
        {
            if (Hopi.Instance.GetFildattente().Count == 0)
            {
                Console.WriteLine("La file d'attente est vide.");
                return;
            }
            Console.WriteLine("Patients en attente:");
            foreach (Patient patient in fileAttente)
            {
                Console.WriteLine($"{patient.Prenom} {patient.Nom}");
            }
        }

        private void NotifierPatient(Patient patient, string message)
        {
            Console.WriteLine($" une notification a ete envoyer à {patient.Prenom} {patient.Nom}: {message}");
        }

        public bool QuitterMenu()
        {
            return true;
        }

    }

    class Medecin : User
    {
        private DaoVisite daoVisite = new DaoVisite();
        private const int MAX_CONSULTATION = 10;
        public int consultationCounter = 9;
        Visite visiteResult = new Visite();
        List<Visite> liVis = new List<Visite>();


        public Salle salle;

        public Medecin() : base() { }

        public Medecin(Salle salle) : base()
        {
            this.salle = salle;

        }

        public Medecin(string nom, Metier metier) : base(nom, metier) { }

        public Medecin(string nom, Metier metier, Salle salle) : base(nom, metier)
        {
            this.salle = salle;

        }

        public Medecin(string login, string password, string nom, Metier metier) : base(login, password, nom, metier)
        {

        }
        public Visite GestionSalle()
        {

            // Traiter le prochain patient de la file d'attente
            Patient patient = fileAttente.Dequeue();
            Hopi.Instance.SupprimerPatFilDattente(patient);
            salle.Patient = patient;
            salle.Occupe = true;

            NotifierPatient(patient);
            
            Console.WriteLine($"Nom: {patient.Nom} | Prénom: {patient.Prenom} | Âge: {patient.Age}");


            Console.WriteLine($"Prix de la consultation.");
            int tarif = Int32.Parse(Console.ReadLine());

            Visite v = new Visite(patient.Id, DateTime.Now, this.metier.ToString(), tarif, salle.Numero);
            return v;
        }
        public void ConfigurerSallePourConsultation(Medecin medecin)
        {
            int salleNumero = (int)medecin.Metier;
            medecin.salle = new Salle() { Numero = salleNumero };

            bool estTerminé = true;

            if (fileAttente.Count == 0)
            {
                Console.WriteLine("Aucune personne à recevoir");
                return;
            }

            visiteResult = medecin.GestionSalle();
            this.liVis.Add(visiteResult);

            Console.WriteLine("La visite  est elle terminée ?(True or False)");
            estTerminé = bool.Parse(Console.ReadLine());
            while (!estTerminé)
            {
                Console.WriteLine("La visite  est elle terminée ?(True or False)");
                estTerminé = bool.Parse(Console.ReadLine());

            }

            medecin.TerminerConsultation();
        }


        public void TerminerConsultation()
        {
            consultationCounter++;

            if (consultationCounter == MAX_CONSULTATION)
            {
                Console.WriteLine($"Vous avez fait {MAX_CONSULTATION} visites");
                consultationCounter=0;


            }


            salle.Occupe = false;
            salle.Patient = null;


            Console.WriteLine($"Salle {salle.Numero} est maintenant libre.");
        }


        public void AfficherFileAttente()
        {
            if (Hopi.Instance.GetFildattente().Count == 0)
            {
                Console.WriteLine("La file d'attente est vide.");
                return;
            }
            Console.WriteLine("Patients en attente:");
            foreach (Patient patient in fileAttente)
            {
                Console.WriteLine($"{patient.Prenom} {patient.Nom}");
            }
        }


        public void AfficherLaListeDesVisites()
        {
            List<Visite> lvi = daoVisite.SelectAll();
            foreach (Visite vi in lvi)
                Console.WriteLine(vi);
        }


        public void SauvegardeVisites()
        {


            if (this.liVis != null)
            {
                foreach (Visite vi in liVis)
                {
                    daoVisite.Insert(vi);

                }

                return;

            }
            Console.WriteLine("il n y a rien à enregistrer");
        }



        public void NotifierPatient(Patient patient)
        {
            Console.WriteLine($"Patient {patient.Nom} {patient.Prenom} a reçu une notification");
            patient.RecevoirMessage(this.salle.Numero);
            return;

        }


        public bool QuitterMenu()
        {
            return true;
        }

    }
}


public enum Metier
{
    secretaire = 0,
    medecin1 = 1,
    medecin2 = 2
}

