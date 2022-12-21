using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class MoleculeQuestionModel : Model
{
    private string table = "multiple_choice";


    public IDbConnection CreateAndOpenDatabase() 
    { 
        return CreateAndOpenDatabase("CREATE TABLE IF NOT EXISTS 'molecule_questions' ("
	            + "'id' INTEGER,"
	            + "'Question'	TEXT,"
	            + "'Answer' TEXT,"
	            + "PRIMARY KEY('id' AUTOINCREMENT));");
    }

    public void InsertData(IDbConnection dbConnection, string question, string Answer)
    {
        Dictionary <string, string> data = new Dictionary<string, string>();
        data.Add("Question", question);
        data.Add("Answer", Answer);
        InsertData(dbConnection, table, data);
    }

    public void UpdateData(IDbConnection dbConnection, int id, string question, string Answer) 
    {
        Dictionary <string, string> data = new Dictionary<string, string>();
        data.Add("Question", question);
        data.Add("Answer", Answer);
        UpdateData(dbConnection, table, id, data);
    }

    public IDataReader ReadData(IDbConnection dbConnection) 
    {
        return ReadData(dbConnection, table);
    }

    public void DeleteData(IDbConnection dbConnection, int id) 
    {
        DeleteData(dbConnection, table, id);
    }
}
