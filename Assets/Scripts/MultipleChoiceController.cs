
using System.Runtime.Serialization;
using System.Reflection.Emit;
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
    private ArrayList difficulties = new ArrayList();
    
    


    private int previousQuestion = 0;
    
    [SerializeField]
    private GameObject dbObj;
    MultipleChoiceModel db;
// Start is called before the first frame update
    void Start()
    {   
        
        db = dbObj.GetComponent<MultipleChoiceModel>();
        // QuestionModel model = new QuestionModel();
        // model.CreateAndOpenDatabase();
        IDbConnection con = db.CreateAndOpenDatabase();
    
        //insert data
        // db.InsertData(con, "Which three atoms are commonly found in monosaccharides?", "C,H,O", "C,H,O", "C,H,O", "C,H,O");
         

        IDataReader reader = db.ReadData(con);
        while (reader.Read()) // 17
        {
            Questions.Add(reader.GetString(1));
            RightAnswers.Add(reader.GetString(2));
            WrongAnswers1.Add(reader.GetString(3));
            WrongAnswers2.Add(reader.GetString(4));
            WrongAnswers3.Add(reader.GetString(5));
            difficulties.Add(reader.GetInt32(6));
            Debug.Log("Question: " + reader.GetString(1) + " Right Answer: " + reader.GetString(2) + " Wrong Answer 1: " + reader.GetString(3) + " Wrong Answer 2: " + reader.GetString(4) + " Wrong Answer 3: " + reader.GetString(5) + " Difficulty: " + reader.GetInt32(6));
        }
        
        
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

    
}
