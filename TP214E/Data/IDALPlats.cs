using MongoDB.Driver;

namespace TP214E.Data
{
    public interface IDALPlats
    {
        IMongoCollection<Plat> ObtenirPlats();
    }
}
