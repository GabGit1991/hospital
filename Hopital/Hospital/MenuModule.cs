using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    class MenuModule
    {
         public int DisplayMenu(User user)
        {
            if (user == null)
            {
                Console.WriteLine("Accsès refusé.Mauvais login ou mauvais mdp");
                return -1;
            }



            switch (user.Metier)
            {
                case Metier.secretaire:
                    return DisplayMenuSecretaire();


                default:

                    return DisplayMenuMedecin();

            }
        }
        public  int DisplayMenuMedecin()
        {
            Console.WriteLine("Bienvenue,Docteur");
            Console.WriteLine("1. Rendre diponible la salle et  acceuillir un nouveau patient");
            Console.WriteLine("2. Affichage de la liste des visites");
            Console.WriteLine("3. Afficher la file d 'attente");
            Console.WriteLine("4. Sauvegarde en base des visites");
            Console.WriteLine("5. Quitter le menu ");
            return Int32.Parse(Console.ReadLine());


        }

        public int DisplayMenuSecretaire()
        {
            Console.WriteLine("Bienvenue secretaire");
            Console.WriteLine("1. Ajout de patient à la file d'attente");
            Console.WriteLine("2. Affichage de la file d'attente");
            Console.WriteLine("3. Affichage du prochain patient");
            Console.WriteLine("4. Compléter/modifier la fiche patient");
            Console.WriteLine("5. Affichage des visites d'un patient par identifiant");
            Console.WriteLine("6. Retour au menu principal");
            return Int32.Parse(Console.ReadLine());
        }

        public  void InfosPat(out int id, out string nom, out string prenom, out int age)
        {
            Console.WriteLine("Entre id du patient");
            id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entre le nom du patient");
            nom = Console.ReadLine();
            Console.WriteLine("Entre le prenom du patient");
            prenom = Console.ReadLine();
            Console.WriteLine("Entre l'age");
            age = Int32.Parse(Console.ReadLine());


        }
       
    }
}
