using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakery.Models
{
  public class Item
  {        
    public double Price {get; set;}
    public string Name {get; set;}
    private static List<Item> _menu = new List<Item> {};  

    public Item(double price, string name) {
      this.Price = price;
      this.Name = name;
      _menu.Add(this);
    }

    public virtual double Buy (int quantity) {
      return quantity * 0;
    }

    public static int Order()
    {
      int number;
      string selection = Console.ReadLine();
      bool valid = int.TryParse(selection, out number);
      if (valid && number > 0) {
        return number;
      } else {
        return 0;
      }
    }

    public static Dictionary<Item, int> Checkout(Item[] items, int order, Dictionary<Item, int> purchase)
    {
      int quantity = 0;
      Item item = new Item(0, ""); 
      do {
          item = items[order-1];
            if(item.GetType() == typeof(Bread)) {
              Console.WriteLine("\nLe pain est acheté 2 obtenez 1 gratuit");
              Console.WriteLine("The bread is buy 2 get 1 free");
              Console.WriteLine("How many would you like?");          
              quantity = Order();
              while(quantity == 0){
                Console.WriteLine("Please enter a whole number greater than 0");
                quantity = Order();
              }
            } else if (item.GetType() == typeof(Pastry)) {
              Console.WriteLine("\nLes pâtisseries sont acheter 2 obtenir 1 moitié prix");
              Console.WriteLine("Pastries are buy 2 get 1 at half price");
              Console.WriteLine("How many would you like?");
              quantity = Order();
              while(quantity == 0){
                Console.WriteLine("Please enter a whole number greater than 0");
                quantity = Order();
              }
            } else if (item.GetType() == typeof(Appetizer)) {
              Console.WriteLine("\nLes hors-d'œuvre sont tarifés en divisant le prix de chaque article par la place de cet article dans la séquence et en arrondissant.");
              Console.WriteLine("Appetizers are priced by dividing the price of the \'n\'th item by n, rounding up to the nearest whole number, and adding that value to the total cost.");
              Console.WriteLine("How many would you like?");
              quantity = Order();
              while(quantity == 0){
                Console.WriteLine("Please enter a whole number greater than 0");
                quantity = Order();
              }
            } else {
              Console.WriteLine("Please select an quantity by entering a number greater than 0");
            }
        } while (quantity <= 0);
      if(purchase.ContainsKey(item)){
        purchase[item] += quantity;
      } else {
        purchase.Add(item, quantity);
      }
      return purchase;
    }

    public static List<Item> GetAll()
    {
      return _menu;
    }
  }
}