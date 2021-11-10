using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace TP214E.Data
{
    public class DAL : IDAL
    {
        public MongoClient mongoDBClient;
        private IMongoCollection<Aliment> aliments;
        private IMongoCollection<Plat> plats;
        private IMongoCollection<Commande> commandes;


        public DAL()
        {
            mongoDBClient = OuvrirConnexion();
        }

        //DAL Aliments
        public IMongoCollection<Aliment> Aliments()
        {
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
                aliments = db.GetCollection<Aliment>("Aliments");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return aliments;
        }


        public async void AjouterAliment(Aliment aliment)
        {
            await aliments.InsertOneAsync(aliment);
        }

        public void RetirerAliment(Aliment aliment)
        {
            var filtre = Builders<Aliment>.Filter.Eq("_id", aliment._id);
            aliments.DeleteOne(filtre);
        }

        public void ModifierAliment(Aliment aliment, ObjectId idAliment)
        {
            var filtre = Builders<Aliment>.Filter.Eq("_id", idAliment);
            var update = Builders<Aliment>.Update
                .Set("Nom", aliment.Nom)
                .Set("Quantite", aliment.Quantite)
                .Set("ExpireLe", aliment.ExpireLe)
                .Set("Unite", aliment.Unite);
            aliments.UpdateOne(filtre, update);
        }

        //DAL Plats 


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

        //DAL Commandes

        public IMongoCollection<Commande> Commandes()
        {
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
                commandes = db.GetCollection<Commande>("Commandes");
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

        private MongoClient OuvrirConnexion()
        {
            MongoClient dbClient = null;
            try
            {
                dbClient = new MongoClient("mongodb://localhost:27017/TP2DB");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dbClient;
        }

    }
}
