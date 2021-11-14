using MongoDB.Driver;

namespace TP214E.Data
{
    public interface IDALCommande
    {
        void AjouterCommande(Commande commande);
        IMongoCollection<Commande> ObtenirCommandes();
    }
}
