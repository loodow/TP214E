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
    public class CommandeTests
    {
        private Commande commande;
        private Plat lasagne;
        private Plat pizza;
        private Plat burger;
        private Plat ramens;

        [SetUp]
        public void SetUp()
        {
            lasagne = new Plat { Nom = "Lasagne", Prix = 1 };
            pizza = new Plat { Nom = "Pizza", Prix = 2 };
            burger = new Plat { Nom = "Burger", Prix = 3 };
            ramens = new Plat { Nom = "Ramens", Prix = 4 };
        }

        [Test]
        public void ObtenirChaineFormateePlatsEtTotal_NombrePlatsEst1_PasseRien_DevraitRetournerChaineFormateePlatsEtTotal()
        {
            List<Plat> plats = new List<Plat>
            {
                lasagne
            };
            commande = new Commande { Plats = plats };

            string chaineFormateePlatsEtTotal = "Lasagne (1$)";

            Assert.AreEqual(chaineFormateePlatsEtTotal, commande.ObtenirChaineFormateePlatsEtTotal());
        }

        [Test]
        public void ObtenirChaineFormateePlatsEtTotal_NombrePlatsEst2_PasseRien_DevraitRetournerChaineFormateePlatsEtTotal()
        {
            List<Plat> plats = new List<Plat>
            {
                lasagne, pizza
            };
            commande = new Commande { Plats = plats };

            string chaineFormateePlatsEtTotal = "Lasagne, Pizza (3$)";

            Assert.AreEqual(chaineFormateePlatsEtTotal, commande.ObtenirChaineFormateePlatsEtTotal());
        }

        [Test]
        public void ObtenirChaineFormateePlatsEtTotal_NombrePlatsEst3_PasseRien_DevraitRetournerChaineFormateePlatsEtTotal()
        {
            List<Plat> plats = new List<Plat>
            {
                lasagne, pizza, burger
            };
            commande = new Commande { Plats = plats };

            string chaineFormateePlatsEtTotal = "Lasagne, Pizza + 1 autre (6$)";

            Assert.AreEqual(chaineFormateePlatsEtTotal, commande.ObtenirChaineFormateePlatsEtTotal());
        }

        [Test]
        public void ObtenirChaineFormateePlatsEtTotal_NombrePlatsEst4_PasseRien_DevraitRetournerChaineFormateePlatsEtTotal()
        {
            List<Plat> plats = new List<Plat>
            {
                lasagne, pizza, burger, ramens
            };
            commande = new Commande { Plats = plats };

            string chaineFormateePlatsEtTotal = "Lasagne, Pizza + 2 autres (10$)";

            Assert.AreEqual(chaineFormateePlatsEtTotal, commande.ObtenirChaineFormateePlatsEtTotal());
        }

        [Test]
        public void CalculerTotalPrixPlats_PasseRien_DevraitRetourner10()
        {
            List<Plat> plats = new List<Plat>
            {
                lasagne, pizza, burger, ramens
            };
            commande = new Commande { Plats = plats };

            Assert.AreEqual(10, commande.CalculerTotalPrixPlats());
        }

        [Test]
        public void Plats_Passe2PlatsCommeListe_NeDevraitLancerException()
        {
            List<Plat> plats = new List<Plat>
            {
                lasagne, pizza
            };

            Assert.DoesNotThrow(() => commande = new Commande { Plats = plats });
        }

        [Test]
        public void Plats_Passe0PlatsCommeListe_DevraitLancerException()
        {
            List<Plat> plats = new List<Plat>();

            var exception = Assert.Throws<Exception>(() => commande = new Commande { Plats = plats });
            Assert.AreEqual("La liste de plats ne peut pas être vide.", exception.Message);
        }

    }
}
