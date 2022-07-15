using System;

namespace Bakery
{
  public class Item
  {        
    public double Price {get; set;}
    public string Name {get; set;}

    public Item(double price, string name) {
      this.Price = price;
      this.Name = name;
    }

    public virtual double Buy (int quantity) {
      return quantity * 0;
    }
  }

  public class Bread : Item
  {
    public Bread(double price, string name) : base(price, name){ }

    public override double Buy (int quantity) {
      double totalPrice = 0.0;
      for (int i=1; i<=quantity; i++) {
        if (i % 3 == 0) {
          totalPrice += 0;
        } else {
          totalPrice += this.Price;
        }
      }
      return totalPrice;
    }
  }

  public class Pastry : Item
  {
    public Pastry(double price, string name) : base(price, name){ }

    public override double Buy (int quantity) {
      double totalPrice = 0.0;
      for (int i=1; i<=quantity; i++) {
        if (i % 3 == 0) {
          totalPrice += this.Price / 2;
        } else {
          totalPrice += this.Price;
        }
      }
      return totalPrice;
    }
  }

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
  }
}