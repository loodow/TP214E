using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Plat
    {
        public ObjectId Id { get; set; }    
        public List<Aliment> lst_aliments;
        public float Prix { get; set; }




        


    }
}
