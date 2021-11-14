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



    }
}
