using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Hospital
{
    
    class Hopi
    {

        private Secretaire sec;
        private Queue<Patient> fildattente = new Queue<Patient>();


        private static Hopi instance=null ;//"lazy" créé lors de la première demande d'accès via la propriété instance


        private Hopi()
        {

        }

        public static Hopi Instance
        {
            get
            {
                if (instance == null)
                {
                    return instance = new Hopi();
                }
                else
                    return instance;
            }
        }

        public Queue<Patient> GetFildattente()
        {
            return fildattente;
        }

        public void AjouterPatFilDattente(Patient patient)
        {
            fildattente.Enqueue(patient);
        }

        public void SupprimerPatFilDattente(Patient p)
        {
            // Convertir la queue en liste
            List<Patient> tempList = fildattente.ToList();

            if (tempList.Contains(p))
            {
                tempList.Remove(p);
                // reconvertir la queue en liste
                fildattente = new Queue<Patient>(tempList);
            }
        }

    }
}
