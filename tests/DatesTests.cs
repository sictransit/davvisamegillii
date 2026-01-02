namespace net.sictransit.davvisámegillii.tests
{
    [TestClass]
    public class DatesTests
    {
        [TestMethod]
        public void ToDateTest()
        {
            Assert.AreEqual("disdat juovlamánu guđát beaivi", new DateTime(2022, 12, 6).ToDate());
            Assert.Contains("skábmamánu guoktelogiovccát beaivi", new DateTime(2000, 11, 29).ToDate());

        }
    }
}