using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
  public class DinoManager
  {
    public List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();


    public void AddANewDino(string name, string dietType, int weight, int enclosureNumber)
    {
      var dinosaur = new Dinosaur
      {
        Name = name,
        DietType = dietType,
        DateAcquired = DateTime.Now,
        Weight = weight,
        EnclosureNumber = enclosureNumber
      };

      Dinosaurs.Add(dinosaur);

      var dinoOrder = Dinosaurs.OrderBy(dinosaur => dinosaur.DateAcquired).ToList();
    }

    public void DeleteDino(string name)
    {
      var dinoToRemove = Dinosaurs.Where(dinosaur => dinosaur.Name == name).ToList();

      Dinosaurs.Remove(dinoToRemove.First());
    }

    public List<Dinosaur> GetTopThreeHeaviestDinosaurs()
    {

      var heaviestThreeDino = Dinosaurs.OrderByDescending(dinosaur => dinosaur.Weight).ThenBy(dinosaur => dinosaur.Name).Take(3).ToList();

      return heaviestThreeDino;
    }

    public int HerbivoreDietSummary()
    {
      var herbivoreDietSummary = Dinosaurs.Where(dinosaur => dinosaur.DietType == "h").Count();

      return herbivoreDietSummary;
    }

    public int CarnivoreDietSummary()
    {
      var carnivoreDietSummary = Dinosaurs.Where(dinosaur => dinosaur.DietType == "c").Count();

      return carnivoreDietSummary;
    }

    public void TransferEnclosure(string name, string enclosure)
    {
      var transfer = Dinosaurs.First(dinosaur => dinosaur.Name == name);
      transfer.EnclosureNumber = int.Parse(enclosure);
    }


  }
}