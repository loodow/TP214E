using MongoDB.Bson;
using MongoDB.Driver;

namespace TP214E.Data
{
    public interface IDALAliments
    {
        void AjouterAliment(Aliment aliment);
        IMongoCollection<Aliment> ObtenirAliments();
        void ModifierAliment(Aliment aliment, ObjectId idAliment);
        void RetirerAliment(Aliment aliment);
    }
}