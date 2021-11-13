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
    public class PlatTests
    {

        [Test]
        public void TestSetPrixNegatif_DevraitRaiseException()
        {
            Plat plat = new Plat();

            var exception = Assert.Throws<Exception>(() => plat.Prix = -5);

            Assert.AreEqual("Le prix ne peut être négatif", exception.Message);

        }

        [Test]
        public void TestSetGetPrixNegatif_DevraitPasRaiseException()
        {
            Plat plat = new Plat();

            double prix = 23.23;

            plat.Prix = prix;

            Assert.AreEqual(plat.Prix, prix);
        }
    }
}
