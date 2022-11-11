using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System;
using System.Drawing;
using System.Collections;
using Random=UnityEngine.Random;
using Color=UnityEngine.Color;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;

public class MultipleChoiceController : MonoBehaviour
{

//Texts
    [SerializeField] private GameObject question;
    [SerializeField] private GameObject rightText;
    [SerializeField] private GameObject wrongText1;
    [SerializeField] private GameObject wrongText2;
    [SerializeField] private GameObject wrongText3;

// Buttons
    [SerializeField] private GameObject rightAnswer;
    [SerializeField] private GameObject wrongAnswer1;
    [SerializeField] private GameObject wrongAnswer2;
    [SerializeField] private GameObject wrongAnswer3;

    private ArrayList x = new ArrayList();
    private ArrayList y = new ArrayList();

    [SerializeField] private GameObject resultCanvas;
    [SerializeField] private GameObject resultText;

    private ArrayList Questions = new ArrayList();
    private ArrayList RightAnswers = new ArrayList();
    private ArrayList WrongAnswers1 = new ArrayList(); 
    private ArrayList WrongAnswers2 = new ArrayList();
    private ArrayList WrongAnswers3 = new ArrayList();   

    private int previousQuestion = 0;

// Start is called before the first frame update
    void Start()
    {

        
        // QuestionModel model = new QuestionModel();
        // model.CreateAndOpenDatabase();
        IDbConnection con = CreateAndOpenDatabase();
    
        

        ReadData(con);
        
        
        //---------------------------------//
        

        setButtonPositions();

        newQuestion();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Generates a new question from the question and answer ArrayLists
    public void newQuestion()  {
        
        int random = Random.Range(0, Questions.Count);
        if(random == previousQuestion) {
            newQuestion();
        } else {
            buttonRandomizer();
            question.GetComponent<Text>().text = (string)Questions[random];
            rightText.GetComponent<Text>().text = (string)RightAnswers[random];
            wrongText1.GetComponent<Text>().text = (string)WrongAnswers1[random];
            wrongText2.GetComponent<Text>().text = (string)WrongAnswers2[random];
            wrongText3.GetComponent<Text>().text = (string)WrongAnswers3[random];
            previousQuestion = random;
        }
    }

    // Puts each button into 4 random different positions
    public void buttonRandomizer() {

        int random = Random.Range(0, x.Count);
        
        rightAnswer.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)x[random], (float)y[random]);
        x.RemoveAt(random);
        y.RemoveAt(random);
        
        random = Random.Range(0, x.Count);
        wrongAnswer1.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)x[random], (float)y[random]);
        x.RemoveAt(random);
        y.RemoveAt(random);
        
        random = Random.Range(0, x.Count);
        wrongAnswer2.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)x[random], (float)y[random]);
        x.RemoveAt(random);
        y.RemoveAt(random);
        
        random = Random.Range(0, x.Count);
        wrongAnswer3.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)x[random], (float)y[random]);
        x.RemoveAt(random);
        y.RemoveAt(random);

        setButtonPositions();

    }

    
    // Sets the 4 possible button position into x and y ArrayLists
    public void setButtonPositions() {
        // Positions adding

        // Button1
        x.Add(-140.3f);
        y.Add(-90f);
        
        //Button2
        x.Add(131.6f);
        y.Add(-90.4f);

        //Button3
        x.Add(-140.3f);
        y.Add(-155f);

        //Button4
        x.Add(131.6f);
        y.Add(-155f);
    }

    //RightAnswer Onclick
    public void RightAnswer()
    {
        resultText.GetComponent<Text>().text = "Correct!";
        resultCanvas.SetActive(true);
    }

    //WrongAnswer Onclick
    public void WrongAnswer()
    {
        resultText.GetComponent<Text>().text = "Incorrect!";
        resultCanvas.SetActive(true);
    }

    //PressContinue Onclick
    public void pressContinue(){
        resultCanvas.SetActive(false);
        newQuestion();
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

    private void InsertData(IDbConnection dbConnection, string question, string right_answer, string wrong_answer1, string wrong_answer2, string wrong_answer3) // 9
    {
        IDbCommand dbCommandInsert = dbConnection.CreateCommand(); // 10
        dbCommandInsert.CommandText = "INSERT INTO 'questions' ('question', 'right_answer', 'wrong_answer1', 'wrong_answer2', 'wrong_answer3') VALUES ('" + question + "', '" + right_answer + "', '" + wrong_answer1 + "', '" + wrong_answer2 + "', '" + wrong_answer3 + "');"; // 11
        dbCommandInsert.ExecuteReader(); // 12
    }

    private void UpdateData(IDbConnection dbConnection, int id, string question, string right_answer, string wrong_answer1, string wrong_answer2, string wrong_answer3) // 29
    {
        IDbCommand dbCommandUpdate = dbConnection.CreateCommand(); // 30
        dbCommandUpdate.CommandText = "UPDATE 'questions' SET question = '" + question + "', right_answer = '" + right_answer + "', wrong_answer1 = '" + wrong_answer1 + "', wrong_answer2 = '" + wrong_answer2 + "', wrong_answer3 = '" + wrong_answer3 + "' WHERE id = " + id + ";"; // 31
        dbCommandUpdate.ExecuteReader(); // 32
    }

    private void ReadData(IDbConnection dbConnection) // 13
    {
        IDbCommand dbCommandRead = dbConnection.CreateCommand(); // 14
        dbCommandRead.CommandText = "SELECT * FROM 'questions'"; // 15
        IDataReader reader = dbCommandRead.ExecuteReader(); // 16

        while (reader.Read()) // 17
        {
            Questions.Add(reader.GetString(1));
            RightAnswers.Add(reader.GetString(2));
            WrongAnswers1.Add(reader.GetString(3));
            WrongAnswers2.Add(reader.GetString(4));
            WrongAnswers3.Add(reader.GetString(5));
        }
    }

    private void DeleteData(IDbConnection dbConnection, int id) // 25
    {
        IDbCommand dbCommandDelete = dbConnection.CreateCommand(); // 26
        dbCommandDelete.CommandText = "DELETE FROM 'questions' WHERE id = " + id + ";"; // 27
        dbCommandDelete.ExecuteReader(); // 28
    }

    
}
