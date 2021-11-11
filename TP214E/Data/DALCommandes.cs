using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace TP214E.Data
{
    public class DALCommandes: DAL
    {
        private IMongoCollection<Commande> commandes;
        private IMongoCollection<Plat> plats;
        private const string NOM_COLLECTION_COMMANDES = "Commandes";
        //DAL Commandes

        public IMongoCollection<Commande> Commandes()
        {
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase(NOM_BD);
                commandes = db.GetCollection<Commande>(NOM_COLLECTION_COMMANDES);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return commandes;
        }


        public async void AjouterCommande(Commande commande)
        {
            await commandes.InsertOneAsync(commande);
        }

        public IMongoCollection<Plat> Plats()
        {
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
                plats = db.GetCollection<Plat>("Plats");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return plats;
        }
    }
}
