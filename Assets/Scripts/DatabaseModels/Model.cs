using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class Model : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private IDbConnection CreateAndOpenDatabase() // 3
    {
        // Open a connection to the database.
        string dbUri = "URI=file:Assets/db/MyDatabase.db"; // 4
        IDbConnection dbConnection = new SqliteConnection(dbUri); // 5
        dbConnection.Open(); // 6

        // Create a table for the hit count in the database if it does not exist yet.
        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand(); // 6
        dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS 'questions' ("
	            + "'id' INTEGER,"
	            + "'Question'	TEXT,"
	            + "'right_answer' TEXT,"
	            + "'wrong_answer1'	TEXT,"
	            + "'wrong_answer2'	TEXT,"
	            + "'wrong_answer3'	TEXT,"
	            + "PRIMARY KEY('id'));"; // 7
        dbCommandCreateTable.ExecuteReader(); // 8

        return dbConnection;
    }
    
    public void InsertData(IDbConnection dbConnection, string question, string right_answer, string wrong_answer1, string wrong_answer2, string wrong_answer3) // 9
    {
        IDbCommand dbCommandInsert = dbConnection.CreateCommand(); // 10
        dbCommandInsert.CommandText = "INSERT INTO 'Questions' ('Question', 'right_answer', 'wrong_answer1', 'wrong_answer2', 'wrong_answer3') VALUES ('" + question + "', '" + right_answer + "', '" + wrong_answer1 + "', '" + wrong_answer2 + "', '" + wrong_answer3 + "');"; // 11
        dbCommandInsert.ExecuteReader(); // 12
    }

    private void UpdateData(IDbConnection dbConnection, int id, string question, string right_answer, string wrong_answer1, string wrong_answer2, string wrong_answer3) // 29
    {
        IDbCommand dbCommandUpdate = dbConnection.CreateCommand(); // 30
        dbCommandUpdate.CommandText = "UPDATE 'Questions' SET Question = '" + question + "', right_answer = '" + right_answer + "', wrong_answer1 = '" + wrong_answer1 + "', wrong_answer2 = '" + wrong_answer2 + "', wrong_answer3 = '" + wrong_answer3 + "' WHERE id = " + id + ";"; // 31
        dbCommandUpdate.ExecuteReader(); // 32
    }

    // private void ReadData(IDbConnection dbConnection) // 13
    // {
    //     IDbCommand dbCommandRead = dbConnection.CreateCommand(); // 14
    //     dbCommandRead.CommandText = "SELECT * FROM 'Questions'"; // 15
    //     IDataReader reader = dbCommandRead.ExecuteReader(); // 16

    //     while (reader.Read()) // 17
    //     {
    //         Questions.Add(reader.GetString(1));
    //         RightAnswers.Add(reader.GetString(2));
    //         WrongAnswers1.Add(reader.GetString(3));
    //         WrongAnswers2.Add(reader.GetString(4));
    //         WrongAnswers3.Add(reader.GetString(5));
    //     }
    // }

    private void DeleteData(IDbConnection dbConnection, int id) // 25
    {
        IDbCommand dbCommandDelete = dbConnection.CreateCommand(); // 26
        dbCommandDelete.CommandText = "DELETE FROM 'Questions' WHERE id = " + id + ";"; // 27
        dbCommandDelete.ExecuteReader(); // 28
    }
}
