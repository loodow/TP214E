using System;
using System.Windows;
using MongoDB.Driver;


namespace TP214E.Data
{
    public class DALPlats: DAL
    {
        private const string NOM_COLLECTION_PLATS = "Plats";
        private IMongoCollection<Plat> plats;

        public IMongoCollection<Plat> ObtenirPlats()
        {
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase(NOM_BD);
                plats = db.GetCollection<Plat>(NOM_COLLECTION_PLATS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MESSAGE_ERR_CONNEXION_MONGODB + ex.Message, ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return plats;
        }
    }
}
