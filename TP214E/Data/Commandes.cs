using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Commandes
    {
        public Commandes()
        {

        }

        public ObjectId _id { get; set; }
        public List<Plat> PlatsCommandes { get; set; }
        public string TypePaiement { get; set; }

    }
}
