namespace Bakery
{
  public class Item
  {        
    public double Price {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}

    public Item(double price, string name, string description) {
      this.Price = price;
      this.Name = name;
      this.Description = description;
    }

    public virtual double Buy (int quantity) {
      return quantity * 0;
    }
  }

  public class Bread : Item
  {

    public Bread(double price, string name, string description) : base(price, name, description){ }

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

    public Pastry(double price, string name, string description) : base(price, name, description){ }

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
}