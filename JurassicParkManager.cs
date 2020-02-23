using System;
using System.Collections.Generic;
using System.Linq;


namespace JurassicPark
{
  public class JurassicParkManager
  {
    public void StartSimulator()
    {
      {

        Console.Clear();

        var manager = new DinoManager();

        var dinoAscii = new DinoArt();

        dinoAscii.Longneck();

        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("     Welcome to Jurassic Park! We spared no expense when building it!");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
        Console.WriteLine("\nWhat would you like to do?");

        bool leaving = false;
        while (!leaving)
        {
          Console.WriteLine("\n**************************************************************");
          Console.WriteLine("*     (View - V) (Add - A) (Remove - R) (Transfer - T)       *");
          Console.WriteLine("*   (View the Heaviest - H) (Diet Summary - D) (Quit - Q)    *");
          Console.WriteLine("**************************************************************");

          var input = Console.ReadLine().ToLower();

          if (input == "a")
          {
            Console.WriteLine("\nWhat's your dinosaur's name?");
            var name = Console.ReadLine();
            Console.WriteLine("Are they an herbivore (h) or a carnivore(c)?");
            var dietType = Console.ReadLine();
            Console.WriteLine("How many pounds to they weigh?");
            var weight = int.Parse(Console.ReadLine());
            Console.WriteLine("What is their Enclosure Number?");
            var enclosureNumber = int.Parse(Console.ReadLine());

            manager.AddANewDino(name, dietType, weight, enclosureNumber);

          }
          else if (input == "v")
          {
            foreach (var dinosaur in manager.Dinosaurs)
            {
              Console.WriteLine($"\n{dinosaur.Name} / {dinosaur.DietType} / {dinosaur.DateAcquired} / {dinosaur.Weight} lbs / Enclosure #{dinosaur.EnclosureNumber}");
            }
          }
          else if (input == "r")
          {
            Console.WriteLine("Which dinosaur would you like to remove?");
            var dino = Console.ReadLine();

            manager.DeleteDino(dino);
          }
          else if (input == "t")
          {
            Console.WriteLine("Which dinosaur would you like to move?");
            var name = Console.ReadLine();

            Console.WriteLine("Which enclosure number would you like to move them to?");
            var enclosure = Console.ReadLine();

            manager.TransferEnclosure(name, enclosure);
          }
          else if (input == "h")
          {
            var heaviestDinosaurs = manager.GetTopThreeHeaviestDinosaurs();

            heaviestDinosaurs.ForEach(dinosaur =>
            {
              Console.WriteLine($"Name: {dinosaur.Name} Weight: {dinosaur.Weight}");
            });

          }
          else if (input == "d")
          {
            var herbivoreDietSummary = manager.HerbivoreDietSummary();
            var carnivoreDietSummary = manager.CarnivoreDietSummary();

            Console.WriteLine($"There are {herbivoreDietSummary} Herbivores and {carnivoreDietSummary} Carnivores");

          }
          else if (input == "q")
          {
            leaving = true;
          }

        }

      }
    }
  }
}