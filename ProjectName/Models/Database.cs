using System;
using MySql.Data.MySqlClient;
using WorldMap;

namespace WorldMap.Models
{
  public class DB
  {
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}