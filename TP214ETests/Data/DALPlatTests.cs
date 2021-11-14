using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using MongoDB.Driver;
using Assert = NUnit.Framework.Assert;

namespace TP214ETests.Data
{
    [TestFixture]
    public class DALPlatsTests
    {
        private Mock<IDALPlats> dalPlats;
        private Plat lasagne;
        private Plat pizza;

        [SetUp]
        public void SetUp()
        {
            dalPlats = new Mock<IDALPlats>();
            lasagne = new Plat { Nom = "Lasagne", Prix = 1 };
            pizza = new Plat { Nom = "Pizza", Prix = 2 };
        }

        [Test]

        public void ObtenirPlats_RetourneBienPlats()
        {
            List<Plat> lstPlats = new List<Plat> { pizza, lasagne};

            dalPlats.Setup(x=> x.ObtenirPlats()).Returns((IMongoCollection<Plat>)lstPlats);

            lstPlats = dalPlats.Object.ObtenirPlats().Aggregate().ToList();

            Assert.AreEqual(lstPlats, dalPlats.Object.ObtenirPlats());
        }

    }
}
