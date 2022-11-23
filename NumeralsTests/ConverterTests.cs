using Microsoft.VisualStudio.TestTools.UnitTesting;
using Davvisámegillii.Numerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            Assert.AreEqual("duhat", 1000.ToNumeral());
            Assert.AreEqual("duhatlogi", 1010.ToNumeral()); 
            Assert.AreEqual("duhatgolbmanuppelohkái", 1013.ToNumeral());
            Assert.AreEqual("duhatčuođiovccinuppelohkái", 1119.ToNumeral());
            Assert.AreEqual("guokteduhat", 2000.ToNumeral());
            Assert.AreEqual("vihttanuppelohkáiduhatokta", 15001.ToNumeral());
            Assert.AreEqual("čuođiguoktelogigolbmaduhatnjeallječuođivihttalogiguhtta", 123456.ToNumeral());
        }
    }
}