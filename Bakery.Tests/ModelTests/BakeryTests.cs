using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery;

namespace Bakery.Tests
{
  [TestClass]
  public class BreadTests
  {
    [TestMethod]
    public void BuyBread_ReturnTheCostOfOneLoaf_Double()
    {
      Bread testBread = new Bread(5, "", "");

      Assert.AreEqual(5, testBread.BuyBread(1));
    }

    [TestMethod]
    public void BuyBread_ReturnTheCostOfThreeLoaves_Double()
    {
      Bread testBread = new Bread(5, "", "");

      Assert.AreEqual(10, testBread.BuyBread(3));
    }
  }
}