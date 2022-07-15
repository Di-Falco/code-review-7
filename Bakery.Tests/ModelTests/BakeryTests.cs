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
      Bread testBread = new Bread(5, "");

      Assert.AreEqual(5, testBread.Buy(1));
    }

    [TestMethod]
    public void BuyBread_ReturnTheCostOfThreeLoaves_Double()
    {
      Bread testBread = new Bread(5, "");

      Assert.AreEqual(10, testBread.Buy(3));
    }

    [TestMethod]
    public void BuyPastry_ReturnTheCostOfOnePastry_Double()
    {
      Pastry testPastry = new Pastry(2, "");

      Assert.AreEqual(2, testPastry.Buy(1));
    }
    [TestMethod]
    public void BuyPastry_ReturnTheCostOfThreePastries_Double()
    {
      Pastry testPastry = new Pastry(2, "");

      Assert.AreEqual(5, testPastry.Buy(3));
    }

    [TestMethod]
    public void BuyAppetizer_ReturnTheCostOfOneAppetizer_Double()
    {
      Appetizer testAppetizer = new Appetizer(4, "");

      Assert.AreEqual(4, testAppetizer.Buy(1));
    }
    [TestMethod]
    public void BuyAppetizer_ReturnTheCostOfTwoAppetizers_Double()
    {
      Appetizer testAppetizer = new Appetizer(4, "");

      Assert.AreEqual(6, testAppetizer.Buy(2));
    }
  }
}