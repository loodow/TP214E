using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TP214E.Data
{
    public interface IDALPlats
    {
        IMongoCollection<Plat> ObtenirPlats();

    }
}
