using System;
using Bakery;

namespace Bakery
{
  public class Program
  {
    public static void Main()
    {
      Bread baguette = new Bread(5, "Baguette", "/baˈɡet/\nnoun: a long, narrow loaf of French bread.");
      Pastry eclair = new Pastry(2, "Eclair", "/āˈkler,iˈkler/\nnoun: a small, soft, log-shaped pastry filled with cream and typically topped with chocolate icing.");

      Welcome(baguette, eclair);
      int order = Order();
      int quantity;
      switch(order){
        case 1:
          Console.WriteLine("\nLe pain est acheté 2 obtenez 1 gratuit");
          Console.WriteLine("\nThe bread is buy 2 get 1 free");
          quantity = Order();
          while(quantity == 0){
            Console.WriteLine("\nVeuillez entrer un nombre supérieur à 0");
            Console.WriteLine("\nPlease enter a whole number greater than 0");
            quantity = Order();
          }
          baguette.Buy(quantity);
          break;
        case 2:
          Console.WriteLine("\nLes pâtisseries sont acheter 2 obtenir 1 moitié prix");
          Console.WriteLine("\nPastries are buy 2 get 1 at half price");
          quantity = Order();
          while(quantity == 0){
            Console.WriteLine("\nVeuillez entrer un nombre supérieur à 0");
            Console.WriteLine("\nPlease enter a whole number greater than 0");
            quantity = Order();
          }
          eclair.Buy(quantity);
          break;
        case 0:
          Console.WriteLine("Veuillez entrer 1 ou 2");
          Console.WriteLine("Please enter 1 for baguette or 2 for eclair");
          Main();
          break;
      }
    }

    public static void Welcome(Bread baguette, Pastry eclair)
    {
      Console.WriteLine("\nBienvenu à La Pâtisserie de Pierre\nLe Menu:");
      Console.WriteLine("\n"+baguette.Name+" — $"+string.Format("{0:0.00}",baguette.Price)+"\n"+baguette.Description);
      Console.WriteLine("\n"+eclair.Name+" — $"+string.Format("{0:0.00}",eclair.Price)+"\n"+eclair.Description);
      Console.WriteLine("\nQue désirez-vous?\n(1) baguette\n(2) eclair");
    }

    public static int Order()
    {
      int number;
      string selection = Console.ReadLine();
      bool valid = int.TryParse(selection, out number);
      if (valid) {
        return number;
      } else {
        return 0;
      }
    }
  }
}