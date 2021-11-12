using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Commande
    {
        public Commande()
        {
        }

        public ObjectId _id { get; set; }
        private List<Plat> plats;

        public List<Plat> Plats
        {
            get
            {
                return plats;
            }

            set
            {
                if (value.Count > 0)
                {
                    plats = value;
                } 
                else
                {
                    throw new Exception("La liste de plats ne peut pas être vide.");
                }
            }
        }

        public string ChaineFormateePlatsEtTotal
        {
            get { return ObtenirChaineFormateePlatsEtTotal(); }
        }

        public string ObtenirChaineFormateePlatsEtTotal()
        {
            if (Plats.Count == 1)
            {
                return $"{Plats[0].Nom} ({CalculerTotalPrixPlats()}$)";
            }
            else if (Plats.Count == 2)
            {
                return $"{Plats[0].Nom}, {Plats[1].Nom} ({CalculerTotalPrixPlats()}$)";
            }
            else if (Plats.Count == 3)
            {
                return $"{Plats[0].Nom}, {Plats[1].Nom} + 1 autre ({CalculerTotalPrixPlats()}$)";
            }
            else if (Plats.Count > 3)
            {
                return $"{Plats[0].Nom}, {Plats[1].Nom} + {Plats.Count - 2} autres ({CalculerTotalPrixPlats()}$)";
            }

            return "Aucun plats dans la commande";
        }

        public double CalculerTotalPrixPlats()
        {
            double total = 0;

            foreach (Plat plat in Plats)
                total += plat.Prix;

            return Math.Round(total, 2);
        }
    }
}
