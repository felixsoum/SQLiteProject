using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Data;

public static class WeaponDao
{
    public static string DatabasePath { get; set; }

    public static List<Weapon> GetAll()
    {
        IDbConnection connection = new SqliteConnection(DatabasePath);
        connection.Open();
        IDbCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Weapons";
        IDataReader reader = command.ExecuteReader();

        var weappons = new List<Weapon>();
        while (reader.Read())
        {
            weappons.Add(new Weapon(reader.GetString(0), reader.GetInt32(1)));
        }

        reader.Close();
        connection.Close();
        return weappons;
    }
}
