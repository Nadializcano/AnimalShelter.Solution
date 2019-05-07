using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using AnimalShelter;

namespace AnimalShelter.Models
{
  public class Animal
  {
    private int _id;
    private string _type;
    private string _name;
    private string _sex;
    private DateTime _dateOfAdmittance;
    private string _breed;

    public Animal (string type, string name, string sex, DateTime dateOfAdmittance, string breed, int id=0)
    {
      _id = id;
      _type = type;
      _name = name;
      _sex = sex;
      _dateOfAdmittance = dateOfAdmittance;
      _breed = breed;
    }
    public int GetId()
    {
      return _id;
    }
    public void SetId(int id)
    {
      _id = id;
    }
    public string GetAnimalType()
    {
      return _type;
    }
    public void SetAnimalType(string type)
    {
      _type = type;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string name)
    {
      _name = name;
    }
    public string GetSex()
    {
      return _sex;
    }
    public void SetSex(string sex)
    {
      _sex = sex;
    }
    public DateTime GetDateOfAdmittance()
    {
      return _dateOfAdmittance;
    }
    public void SetDateOfAdmittance(DateTime dateOfAdmittance)
    {
      _dateOfAdmittance = dateOfAdmittance;
    }
    public string GetBreed()
    {
      return _breed;
    }
    public void SetBreed(string breed)
    {
      _breed = breed;
    }
    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM animals;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}