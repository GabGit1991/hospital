using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu();
        }
        

        static void Menu()
        {
            User authUser = Authenticate();

            if (authUser == null)
            {
                Console.WriteLine("Accsès refusé.");
                Menu();
                return;
            }
            NaviguerEntreMenu(authUser);
            Menu();
        }
        // Fonction dédiée à l'authentification de l'utilisateur
        static User Authenticate()
        {
            Console.WriteLine("Enter Login:");
            string login = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            AuthModule authMod = new AuthModule();
            return authMod.AuthenticateUser(login, password);
        }

        static void NaviguerEntreMenu(User authUser)
        {
            MenuModule menuMod = new MenuModule();
            int choix = menuMod.DisplayMenu(authUser);

            switch (authUser.Metier)
            {
                case Metier.secretaire:
                    GestionSecretaireChoix(choix, authUser);
                    break;

                default: // Medecin
                    GestionMedecinChoix(choix, authUser);
                    break;
            }
        }
        static void GestionSecretaireChoix(int choixinit, User u)
        {

            Secretaire sec =   new Secretaire();
            sec.Metier = u.Metier;
            sec.Nom = u.Nom;

            MenuModule menuMod = new MenuModule();

            bool continuer = true;
            int choix = choixinit;

            while (continuer)
            {
                switch (choix)
                {
                    //Ajout de patient à la file d'attente
                    case 1:

                        sec.AjouterPatient();
                        break;

                    // Affichage de la file d'attente
                    case 2:

                        sec.AfficherFileAttente();
                        break;
                    //Affichage du prochain patient
                    case 3:
                        sec.AffichageProchainPatient();
                        break;
                    //Compléter/modifier la fiche patient
                    case 4:
                        sec.ModifierPatient();
                        break;
                    //Affichage des visites d'un patient par identifiant
                    case 5:

                        sec.AffichageVisPatId();
                        break;
                    
                    //Quitter Menu
                    case 6:
                        sec.QuitterMenu();
                        continuer = false;
                        Console.WriteLine("Vous quitter le menu secretaire");
                        return;

                    default:
                        Console.WriteLine("Mauvais numero. Essayer encore");
                        break;
                }

                if (continuer)
                {
                    choix = menuMod.DisplayMenuSecretaire();
                }

            }


        }

        static void GestionMedecinChoix(int choixinitial, User us)
        {
            Medecin medecin = us as Medecin;
            


            MenuModule menuMod = new MenuModule();


            bool continuer = true;
            int choix = choixinitial;

            while (continuer)
            {

                switch (choix)
                {
                    //Gestion de la salle 
                    case 1:
                        if (medecin == null)
                        {
                            Console.WriteLine("L'utilisateur fourni n'est pas un médecin.");
                            return;
                        }

                        medecin.ConfigurerSallePourConsultation(medecin);

                        break;
                    //Affichage la liste des visites
                    case 2:
                        medecin.AfficherLaListeDesVisites();
                        break;
                    //Affichage de la file d'attente
                    case 3:
                        medecin.AfficherFileAttente();
                        break;

                    //  Sauvegarde en base des visites
                    case 4:
                        medecin.SauvegardeVisites();
                        break;

                    //Quitter le menu
                    case 5:
                        medecin.QuitterMenu();
                        continuer = false;
                        Console.WriteLine("Vous quitter le menu medecin");
                        return;
                    default:
                        Console.WriteLine("Mauvais numero. Essayer encore");
                        break;
                }

                if (continuer)
                {
                    choix = menuMod.DisplayMenuMedecin();
                }

            }
        }

    }
}
