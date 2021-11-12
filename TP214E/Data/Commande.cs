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
        public List<Plat> PlatsCommande { get; set; }

        public string ChaineFormateePlatsEtTotal
        {
            get { return ObtenirChaineFormateePlatsEtTotal(); }
        }

        public string ObtenirChaineFormateePlatsEtTotal()
        {
            if (PlatsCommande.Count == 1)
            {
                return $"{PlatsCommande[0].Nom} ({CalculerTotalPrixPlats()}$)";
            }
            else if (PlatsCommande.Count == 2)
            {
                return $"{PlatsCommande[0].Nom}, {PlatsCommande[1].Nom} ({CalculerTotalPrixPlats()}$)";
            }
            else if (PlatsCommande.Count == 3)
            {
                return $"{PlatsCommande[0].Nom}, {PlatsCommande[1].Nom} + 1 autre ({CalculerTotalPrixPlats()}$)";
            }
            else if (PlatsCommande.Count > 3)
            {
                return $"{PlatsCommande[0].Nom}, {PlatsCommande[1].Nom} + {PlatsCommande.Count - 2} autres ({CalculerTotalPrixPlats()}$)";
            }

            return "Aucun plats dans la commande";
        }

        public double CalculerTotalPrixPlats()
        {
            double total = 0;

            foreach (Plat plat in PlatsCommande)
                total += plat.Prix;

            return Math.Round(total, 2);
        }
    }
}
