using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;

public static class WeaponDao
{
    public static string DatabasePath { get; set; }

    public static void Insert(string name, int cost)
    {
        ExecuteCommand($"INSERT INTO Weapons VALUES ('{name}', '{cost}')", reader => { });
    }

    public static List<Weapon> GetAll()
    {
        var weapons = new List<Weapon>();
        ExecuteCommand("SELECT * FROM Weapons",
            reader =>
            {
                while (reader.Read())
                {
                    weapons.Add(new Weapon(reader.GetString(0), reader.GetInt32(1)));
                }
            });
        return weapons;
    }

    public static void ExecuteCommand(string commandText, Action<IDataReader> dataHandler)
    {
        IDbConnection connection = new SqliteConnection(DatabasePath);
        connection.Open();
        IDbCommand command = connection.CreateCommand();
        command.CommandText = commandText;
        IDataReader reader = command.ExecuteReader();

        dataHandler(reader);

        reader.Close();
        connection.Close();
    }
}
