using System;
using System.Collections.Generic;
using System.Linq;
using Bakery;

namespace Bakery
{
  public class Program
  {
    static void Main()
    {
      Bread baguette = new Bread(5.00, "Baguette");
      Bread sourdough = new Bread(7.50, "Pain de Campagne");
      Pastry eclair = new Pastry(2.00, "Eclair");
      Pastry macaron = new Pastry(1.50, "Macarón");
      Appetizer escargo = new Appetizer(9.00, "Escargo");
      Appetizer cigarette = new Appetizer(4.00, "Cigarette");
      Item[] items= new Item[] {baguette, sourdough, eclair, macaron, escargo, cigarette};
      Dictionary<Item, int> purchase = new Dictionary<Item, int>();

      Welcome(items);
      double total = 0.0;
      double cost = 0.0;
      bool quit = false;
      do {
        Menu(items);
        int order = Order();
        while (order == 0)
        {
          Console.WriteLine("Please select an item by entering a number 1-6");
          order = Order();
        }
        purchase = Checkout(items, order, purchase);
        cost = purchase.Keys.Last().Buy(purchase.Values.Last());
        total += cost;
        quit = QuitPrompt();
      } while(quit == false);

      Receipt(purchase, total);
    }

    static void Welcome(Item[] items)
    {
      Console.WriteLine("\nBienvenu à La Pâtisserie de Pierre\nLe Menu:");
      for (int i=0; i<items.Length; i++) {
        Console.WriteLine($"{items[i].Name} — ${string.Format("{0:0.00}", items[i].Price)}");
      }
    }

    static void Menu(Item[] items)
    {
      Console.WriteLine("\nQue désirez-vous?");
      for (int i=0; i<items.Length; i++) {
        Console.WriteLine($"({i+1}) {items[i].Name}");
      }
    }

    static int Order()
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

    static int ReOrder()
    {
      int quantity = 0;
      Console.WriteLine("Please enter a whole number greater than 0");
      quantity = Order();
      return quantity;
    }

    static Dictionary<Item, int> Checkout(Item[] items, int order, Dictionary<Item, int> purchase)
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
                quantity = ReOrder();
              }
            } else if (item.GetType() == typeof(Pastry)) {
              Console.WriteLine("\nLes pâtisseries sont acheter 2 obtenir 1 moitié prix");
              Console.WriteLine("Pastries are buy 2 get 1 at half price");
              Console.WriteLine("How many would you like?");
              quantity = Order();
              while(quantity == 0){
                quantity = ReOrder();
              }
            } else if (item.GetType() == typeof(Appetizer)) {
              Console.WriteLine("\nLes hors-d'œuvre sont tarifés en divisant le prix de chaque article par la place de cet article dans la séquence et en arrondissant.");
              Console.WriteLine("Appetizers are priced by dividing the price of the \'n\'th item by n, rounding up to the nearest whole number, and adding that value to the total cost.");
              Console.WriteLine("How many would you like?");
              quantity = Order();
              while(quantity == 0){
                quantity = ReOrder();
              }
            } else {
              Console.WriteLine("Please select an quantity by entering a number greater than 0");
            }
        } while (quantity <= 0);
      purchase.Add(item, quantity);
      return purchase;
    }

    static bool QuitPrompt() {
      string check = " ";
      do {
        Console.WriteLine("Would you like to purchase something else? (Y/N)");
        check = Console.ReadLine().ToLower();
      } while (check != "y" && check != "n");
      if (check == "y"){
        return false;
      } else if (check == "n") {
        return true;
      }
      return false;
    }

    static void Receipt(Dictionary<Item, int> purchase, double cost) 
    {
      Console.WriteLine("Items:");
      for (int i=0; i<purchase.Count; i++) {
        Console.WriteLine($"{i+1}. {purchase.ElementAt(i).Key.Name} — {purchase.ElementAt(i).Value}");
      }
      Console.WriteLine($"Votre total est: ${string.Format("{0:0.00}", cost)}\n\"L'important c'est pas la chute, c'est l'atterrissage\"");
    }
  }
}