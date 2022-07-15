namespace Bakery
{
  public class Item
  {
    public double Price {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}

    public Item () { }

    public Item (double price, string name, string description) {
      Price = price;
      Name = name;
      Description = description;
    }

  }

  public class Bread : Item
  {

    public Bread() { }

    public Bread(double price, string name, string description) {
      Price = price;
      Name = name;
      Description = description;
    }

    public double Buy (int quantity) {
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

    public Pastry() { }

    public Pastry(double price, string name, string description) {
      Price = price;
      Name = name;
      Description = description;
    }

    public double Buy (int quantity) {
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
}