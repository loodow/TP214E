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
        private const string NOM_COLLECTION_COMMANDES = "Commandes";

        public IMongoCollection<Commande> ObtenirCommandes()
        {
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase(NOM_BD);
                commandes = db.GetCollection<Commande>(NOM_COLLECTION_COMMANDES);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MESSAGE_ERR_CONNEXION_MONGODB + ex.Message, ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return commandes;
        }


        public async void AjouterCommande(Commande commande)
        {
            await commandes.InsertOneAsync(commande);
        }

    }
}
