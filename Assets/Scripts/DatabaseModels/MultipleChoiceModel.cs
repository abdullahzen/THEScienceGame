using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class MultipleChoiceModel : Model
{
    private string table = "multiple_choice";


    public IDbConnection CreateAndOpenDatabase() 
    { 
        return CreateAndOpenDatabase("CREATE TABLE IF NOT EXISTS 'multiple_choice' ("
	            + "'id' INTEGER,"
	            + "'Question'	TEXT,"
	            + "'right_answer' TEXT,"
	            + "'wrong_answer1'	TEXT,"
	            + "'wrong_answer2'	TEXT,"
	            + "'wrong_answer3'	TEXT,"
	            + "PRIMARY KEY('id' AUTOINCREMENT));");
    }

    public void InsertData(IDbConnection dbConnection, string question, string right_answer, string wrong_answer1, string wrong_answer2, string wrong_answer3)
    {
        Dictionary <string, string> data = new Dictionary<string, string>();
        data.Add("Question", question);
        data.Add("right_answer", right_answer);
        data.Add("wrong_answer1", wrong_answer1);
        data.Add("wrong_answer2", wrong_answer2);
        data.Add("wrong_answer3", wrong_answer3);
        InsertData(dbConnection, table, data);
    }

    public void UpdateData(IDbConnection dbConnection, int id, string question, string right_answer, string wrong_answer1, string wrong_answer2, string wrong_answer3) 
    {
        Dictionary <string, string> data = new Dictionary<string, string>();
        data.Add("Question", question);
        data.Add("right_answer", right_answer);
        data.Add("wrong_answer1", wrong_answer1);
        data.Add("wrong_answer2", wrong_answer2);
        data.Add("wrong_answer3", wrong_answer3);
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
