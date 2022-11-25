using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Davvisámegillii.Tests
{
    [TestClass()]
    public class DatesTests
    {
        [TestMethod()]
        public void ToDateTest()
        {
            Assert.AreEqual("disdat juovlamánu guđát beaivi", new DateTime(2022, 12, 6).ToDate());
            Assert.IsTrue(new DateTime(2000, 11, 29).ToDate().Contains("skábmamánu guoktelogiovccát beaivi"));

        }
    }
}