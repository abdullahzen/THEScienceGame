using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;


public class Model : MonoBehaviour 
{

    void Start(){

    }
    void Update(){
        
    }
    public IDbConnection CreateAndOpenDatabase(string tableQuery) 
    {
        // Open a connection to the database.
        string dbUri = "URI=file:Assets/db/MyDatabase.db"; 
        IDbConnection dbConnection = new SqliteConnection(dbUri); 
        dbConnection.Open(); 

        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand(); 
        dbCommandCreateTable.CommandText = tableQuery; 
        dbCommandCreateTable.ExecuteReader(); 

        return dbConnection;
    }
    
    public void InsertData(IDbConnection dbConnection, string table, Dictionary<string, string> data )
    {
        string query = "INSERT INTO " + table + " (";
        string values = "VALUES (";
        foreach (KeyValuePair<string, string> entry in data)
        {
            query += entry.Key + ", ";
            values += entry.Value + ", ";
        }
        query = query.Substring(0, query.Length - 2) + ") ";
        values = values.Substring(0, values.Length - 2) + ");";
        query += values;
        Debug.Log(query);
        IDbCommand dbCommandInsert = dbConnection.CreateCommand(); 
        dbCommandInsert.CommandText = query; 
        dbCommandInsert.ExecuteReader(); 
    }

    public void UpdateData(IDbConnection dbConnection, string table, int id, Dictionary<string, string> data )
    {
        string query = "INSERT INTO " + table + " (";
        string values = "VALUES (";
        foreach (KeyValuePair<string, string> entry in data)
        {
            query += entry.Key + ", ";
            values += entry.Value + ", ";
        }
        query = query.Substring(0, query.Length - 2) + ") ";
        values = values.Substring(0, values.Length - 2) + ");";
        query += values;
        Debug.Log(query);
        IDbCommand dbCommandInsert = dbConnection.CreateCommand(); 
        dbCommandInsert.CommandText = query; 
        dbCommandInsert.ExecuteReader(); 
    }

    public IDataReader ReadData(IDbConnection dbConnection, string table) 
    {
        IDbCommand dbCommandRead = dbConnection.CreateCommand(); 
        dbCommandRead.CommandText = "SELECT * FROM '" + table + "'"; 
        return dbCommandRead.ExecuteReader();
    }

    public void DeleteData(IDbConnection dbConnection, string table, int id) 
    {
        IDbCommand dbCommandDelete = dbConnection.CreateCommand(); 
        dbCommandDelete.CommandText = "DELETE FROM '" + table + "' WHERE id = " + id + ";"; 
        dbCommandDelete.ExecuteReader(); 
    }
}
