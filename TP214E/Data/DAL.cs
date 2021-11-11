using System;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TP214E.Data
{
    public class DAL : IDAL
    {
        public MongoClient mongoDBClient;
        private const string CHAINE_CONNEXION_MONGODB = "mongodb://localhost:27017/TP2DB";
        protected const string MESSAGE_ERR_CONNEXION_MONGODB = "Impossible de se connecter à la base de données ";
        protected const string ERREUR = "Erreur";
        private IMongoCollection<Aliment> aliments;
        private IMongoCollection<Plat> plats;
        private IMongoCollection<Commande> commandes;

        public DAL()
        {
            mongoDBClient = OuvrirConnexion();
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
                dbClient = new MongoClient(CHAINE_CONNEXION_MONGODB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MESSAGE_ERR_CONNEXION_MONGODB + ex.Message, ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dbClient;
        }
    }
}
