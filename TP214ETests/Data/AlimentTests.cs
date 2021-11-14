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
    public class AlimentTests
    {
        [Test]
        public void TestGetSetNom()
        {

            Aliment aliment = new Aliment();
            string nom = "toast";

            aliment.Nom = nom;

            Assert.AreEqual(aliment.Nom, nom);
        }

        [Test]
        public void TestGetSetQuantité()
        {

            Aliment aliment = new Aliment();

            int quantite = 2;

            aliment.Quantite = quantite;

            Assert.AreEqual(aliment.Quantite, quantite);

        }

        [Test]

        public void TestGetSetUnite()
        {

            Aliment aliment = new Aliment();

            string unite = "g";

            aliment.Unite = unite;

            Assert.AreEqual(aliment.Unite, unite);

        }

        [Test]
        public void TestGetSetExpireLeFormat()
        {

            Aliment aliment = new Aliment();

            DateTime date = new DateTime().AddMonths(3);

            aliment.ExpireLe = date;

            string str_date = date.ToShortDateString();

            Assert.AreEqual(aliment.ExpireLeSimplifie, str_date);

        }





    }
}
