using System;
using System.Collections.Generic;
using Bakery;

namespace Bakery
{
  public class Program
  {
    static void Main()
    {
      Bread baguette = new Bread(5, "Baguette", "/baˈɡet/\nnoun: a long, narrow loaf of French bread.");
      Pastry eclair = new Pastry(2, "Eclair", "/āˈkler,iˈkler/\nnoun: a small, soft, log-shaped pastry filled with cream and typically topped with chocolate icing.");
      Item[] items= new Item[2] {baguette, eclair};

      Welcome(items);
      double cost;
      do {
        Menu(items);
        int order = Order();
        cost = Checkout(items, order);
      } while(cost == 0);
      Receipt(cost);
    }

    static void Welcome(Item[] items)
    {
      Console.WriteLine("\nBienvenu à La Pâtisserie de Pierre\nLe Menu:");
      for (int i=0; i<items.Length; i++) {
        Console.WriteLine($"\n{items[i].Name} — ${string.Format("{0:0.00}", items[i].Price)}\n{items[i].Description}");
      }
    }

    static void Menu(Item[] items)
    {
      Console.WriteLine("\nQue désirez-vous?");
      Console.WriteLine("What would you like?");
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
      Console.WriteLine("\nVeuillez entrer un nombre supérieur à 0");
      Console.WriteLine("Please enter a whole number greater than 0");
      quantity = Order();
      return quantity;
    }

    static double Checkout(Item[] items, int order)
    {
      int quantity = 0;
      double cost = 0.0;
      for (int i=0; i<items.Length; i++) {
        if (order == i+1) {
          if(items[i].GetType() == typeof(Bread)) {
            Console.WriteLine("\nLe pain est acheté 2 obtenez 1 gratuit");
            Console.WriteLine("The bread is buy 2 get 1 free");
            Console.WriteLine("\nCombien en voudrais-tu?");
            Console.WriteLine("How many would you like?");          
            quantity = Order();
            while(quantity == 0){
              quantity = ReOrder();
            }
            cost = items[i].Buy(quantity);
            break;
          } else if (items[i].GetType() == typeof(Pastry)) {
            Console.WriteLine("\nLes pâtisseries sont acheter 2 obtenir 1 moitié prix");
            Console.WriteLine("Pastries are buy 2 get 1 at half price");
            Console.WriteLine("\nCombien en voudrais-tu?");
            Console.WriteLine("How many would you like?");
            quantity = Order();
            while(quantity == 0){
              quantity = ReOrder();
            }       
            cost = items[i].Buy(quantity);
            break;
          }
        }
      }
      return cost;
    }

    static void Receipt(double cost) 
    {
      Console.WriteLine($"Votre total est: ${string.Format("{0:0.00}", cost)}\n\"L'important c'est pas la chute, c'est l'atterrissage\"");
    }
  }
}