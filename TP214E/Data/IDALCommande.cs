using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TP214E.Data
{
    public interface IDALCommande
    {

        void AjouterCommande(Commande commande);
        IMongoCollection<Commande> ObtenirCommandes();
        IMongoCollection<Plat> ObtenirPlats();


    }
}
