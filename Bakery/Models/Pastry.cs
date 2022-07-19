using System;

namespace Bakery.Models
{
  public class Pastry : Item
  {
    public Pastry(double price, string name) : base(price, name){ }

    public override double Buy (int quantity) {
      double totalPrice = 0.0;
      totalPrice = (quantity * this.Price) - ((quantity/3) * (this.Price/2));
      return totalPrice;
    }

    Pastry eclair = new Pastry(2.00, "Eclair");
    Pastry macaron = new Pastry(1.50, "Macarón");
  }
}