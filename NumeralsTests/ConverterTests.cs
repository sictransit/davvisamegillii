﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Davvisámegillii.Numerals.Tests
{
    [TestClass()]
    public class ConverterTests
    {
        [TestMethod()]
        public void ToNumeralTest()
        {
            Assert.AreEqual("nolla", 0.ToNumeral());
            Assert.AreEqual("okta", 1.ToNumeral());

            Assert.AreEqual("logi", 10.ToNumeral());
            Assert.AreEqual("ovccinuppelohkái", 19.ToNumeral());

            Assert.AreEqual("njealljelogiguokte", 42.ToNumeral());
            Assert.AreEqual("ovccilogi", 90.ToNumeral());
            Assert.AreEqual("ovccilogiovcci", 99.ToNumeral());

            Assert.AreEqual("čuođi", 100.ToNumeral());
            Assert.AreEqual("čuođiokta", 101.ToNumeral());
            Assert.AreEqual("čuođioktanuppelohkái", 111.ToNumeral());
            Assert.AreEqual("njeallječuođiguoktelogi", 420.ToNumeral());
            Assert.AreEqual("ovccičuođiovccilogiovcci", 999.ToNumeral());

            Assert.AreEqual("duhát", 1_000.ToNumeral());
            Assert.AreEqual("duhátlogi", 1_010.ToNumeral());
            Assert.AreEqual("duhátgolbmanuppelohkái", 1_013.ToNumeral());
            Assert.AreEqual("duhátčuođiovccinuppelohkái", 1_119.ToNumeral());
            Assert.AreEqual("guokteduhát", 2_000.ToNumeral());
            Assert.AreEqual("vihttanuppelohkáiduhátokta", 15_001.ToNumeral());
            Assert.AreEqual("čuođiguoktelogigolbmaduhátnjeallječuođivihttalogiguhtta", 123_456.ToNumeral());

            Assert.AreEqual("miljon", 1_000_000.ToNumeral());
            Assert.AreEqual("miljončiežaduhátvihtta", 1_007_005.ToNumeral());
            Assert.AreEqual("vihttamiljovnnaduhátguoktečuođigolbmalogi", 5_001_230.ToNumeral());
            Assert.AreEqual("ovccičuođigávccilogičiežamiljovnnaguhttačuođivihttaloginjealljeduhátgolbmačuođiguoktelogiokta", 987_654_321.ToNumeral());

            Assert.AreEqual("miljárda", 1_000_000_000.ToNumeral());
            Assert.AreEqual("guoktemiljárddačuođinjealljelogičiežamiljovnnanjeallječuođigávccilogigolbmaduhátguhttačuođinjealljelogičieža", int.MaxValue.ToNumeral());
        }

        [TestMethod()]
        public void SvonniToNumeralTest()
        {
            // Ref: [Mikael Svonni] Modern nordsamisk grammatik, 5.7.1.
            Assert.AreEqual("čuohti", 100.ToNumeral());
            Assert.AreEqual("čuođiokta", 101.ToNumeral());
            Assert.AreEqual("vihttačuohti", 500.ToNumeral());
            Assert.AreEqual("vihttačuođičiežalogiovcci", 579.ToNumeral());
            Assert.AreEqual("duhátguhttačuođioktanuppelohkái", 1_611.ToNumeral());
            Assert.AreEqual("guokteduhátgávccinuppelohkái", 2_018.ToNumeral());
        }
    }
}