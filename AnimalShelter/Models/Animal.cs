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
    public static List<Animal> GetAll()
    {
      List<Animal> allAnimals = new List<Animal> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM animals;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int animalId = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string sex = rdr.GetString(2);
        DateTime dateOfAdmittance = rdr.GetDateTime(3);
        string breed = rdr.GetString(4);
        string type = rdr.GetString(5);
        Animal newAnimal = new Animal (type, name, sex, dateOfAdmittance, breed);
        allAnimals.Add(newAnimal);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allAnimals;
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO animals (name, sex, dateofAdmittance, breed, type) VALUES (@name, @sex, @dateOfAdmittance, @breed, @type);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;
      MySqlParameter sex = new MySqlParameter();
      sex.ParameterName = "@sex";
      sex.Value = this._sex;
      MySqlParameter dateOfAdmittance = new MySqlParameter();
      dateOfAdmittance.ParameterName = "@dateOfAdmittance";
      dateOfAdmittance.Value = this._dateOfAdmittance;
      MySqlParameter breed = new MySqlParameter();
      breed.ParameterName = "@breed";
      breed.Value = this._breed;
      MySqlParameter type = new MySqlParameter();
      type.ParameterName = "@type";
      type.Value = this._type;
      cmd.Parameters.Add(name);
      cmd.Parameters.Add(sex);
      cmd.Parameters.Add(dateOfAdmittance);
      cmd.Parameters.Add(breed);
      cmd.Parameters.Add(type);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static Animal Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `Animals` WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int AnimalId = 0;
      string name = "";
      string sex = "";
      string breed = "";
      string type = "":
      DateTime dateOfAdmittance = new DateTime();
      while (rdr.Read())
      {
        AnimalId = rdr.GetInt32(0);
        name = rdr.GetString(1);
        sex = rdr.GetString(2);
        dateOfAdmittance = rdr.GetDateTime(3);
        breed = rdr.GetString(4);
        type = rdr.GetString(5);
      }
      Animal foundAnimal = new Animal(type, name, sex, dateOfAdmittance, breed, AnimalId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundAnimal;
    }
  }
}