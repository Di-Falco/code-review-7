using System;

namespace Bakery.Models
{
  public class Bread : Item
  {
    public Bread(double price, string name) : base(price, name){ }

    public override double Buy (int quantity) {
      double totalPrice = 0.0;
      totalPrice = (quantity * this.Price) - (quantity/3 * this.Price);
      return totalPrice;
    }

    Bread baguette = new Bread(5.00, "Baguette");
    Bread sourdough = new Bread(7.50, "Pain de Campagne");
  }
}