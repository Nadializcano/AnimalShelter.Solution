using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using AnimalShelter.Models;

namespace AnimalShelter.Tests 
{

  [TestClass]
  public class AnimalTest: IDisposable
  {
    public void Dispose()
    {
      Animal.ClearAll();
    }
    public AnimalTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=animalshelter_test;convert zero datetime=True";
    }
    [TestMethod]
    public void AnimalConstructor_CreatesInstanceOfAnimal_Animal()
    {
      string type = "cat";
      string name = "Toby";
      string sex = "male";
      DateTime dateOfAdmittance = new DateTime(2019, 05, 06);
      string breed = "DSH";
      Animal newAnimal = new Animal (type, name, sex, dateOfAdmittance, breed);
      Assert.AreEqual(typeof(Animal), newAnimal.GetType());
    }
  }
}
