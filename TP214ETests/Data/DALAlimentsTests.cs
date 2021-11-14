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
    public class DALAlimentsTests
    {
        private Mock<IDALAliments> dalAliments;

        [SetUp]
        public void SetUp()
        {
            dalAliments = new Mock<IDALAliments>();
        }

        [Test]
        public void AjouterAliment_Aliment_NeDevraitLancerException()
        {
            // arrange
            var aliment = new Aliment();
            aliment.Nom = "nomx";

            dalAliments.Setup(x => x.AjouterAliment(aliment)).Throws(null);

            // assert
            dalAliments.Verify(x => x.AjouterAliment(aliment));
        }

        [Test]
        public void ObtenirAliments_Rien_DevraitRetournerAliments()
        {
            List<Aliment> aliments = new List<Aliment>
            {
                new Aliment { Nom = "Tomate", ExpireLe = new DateTime(2021, 11, 17), Quantite = 2, Unite = "oui" },
                new Aliment { Nom = "Orange", ExpireLe = new DateTime(2022, 5, 26), Quantite = 2, Unite = "oui" }
            };

            IMongoCollection<Aliment> aliments2 = IMongoCollection<Aliment>();


            dalAliments.Setup(x => x.ObtenirAliments()).Returns((IMongoCollection<Aliment>)aliments);
            aliments = dalAliments.Object.ObtenirAliments().Aggregate().ToList();

            Assert.AreEqual(aliments, dalAliments.Object.ObtenirAliments());
        }

        [Test]
        public void RetirerAlimentTest()
        {
            //dalAliments.

            //aliments.DeleteOne(filtre);

            //Assert.Fail();
        }

        [Test]
        public void ModifierAlimentTest()
        {
            Assert.Fail();
        }
    }
}
