using System;

namespace Bakery.Models
{
  public class Appetizer : Item
  {
    public Appetizer(double price, string name) : base(price, name){ }

    public override double Buy (int quantity)
    {
      double totalPrice = 0.0;
      for (int i=1; i<=quantity; i++) {
        totalPrice += Math.Ceiling(this.Price / i);
      }
      return totalPrice;
    }

    Appetizer escargo = new Appetizer(9.00, "Escargo");
    Appetizer cigarette = new Appetizer(4.00, "Cigarette");
  }
}