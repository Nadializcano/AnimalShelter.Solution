using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    [Route("/animals")]
    public ActionResult Index() { return View(); }

    [HttpGet("animals/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpPost("/animals")]
    public ActionResult Create(string type, string name, string sex, DateTime dateOfAdmittance, string breed, int id)
    {
      Animal newAnimal = new Animal(type, name, sex, dateOfAdmittance, breed, id);
      newAnimal.Save();
      List<Animal> allAnimals = Animal.GetAll();
      return View("Index", allAnimals);
    }
    [HttpGet("/categories/{id}")]
    public ActionResult Show(int id)
    {
      Animal selectedAnimal = Animal.Find(id);
      return View(selectedAnimal);
    }
  }
}
