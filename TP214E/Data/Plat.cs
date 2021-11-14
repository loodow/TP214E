using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace TP214E.Data
{
    public class Plat
    {
        public ObjectId _id { get; set; }
        public string Nom { get; set; }

        public List<Aliment> Recette { get; set; }
        public double prix;

        public double Prix
        {
            get
            {
                return prix;
            }

            set
            {
                if (value > 0)
                {
                    prix = value;
                } 
                else
                {
                    throw new Exception("Le prix ne peut être négatif");
                }
            }
        }
    }
}
