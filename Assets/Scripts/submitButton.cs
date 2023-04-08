



using System.Resources;
// using System;
using System.Data.Common;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using TMPro;
using UnityEngine.SceneManagement;

public class submitButton : MonoBehaviour
{
    private Text result;
    private GameObject go;
    private GameObject[] clicked;

    [SerializeField]
    private TextMeshProUGUI  questionText;
    
    [SerializeField]
    private GameObject displayPrefab;    
    [SerializeField]
    private MoleculeQuestionModel db;



    ArrayList userAnswer = new ArrayList();

    ArrayList answer = new ArrayList();
    ArrayList images1 = new ArrayList();
    ArrayList images2 = new ArrayList();
    ArrayList images3 = new ArrayList();
    ArrayList Questions = new ArrayList();
    ArrayList Answers = new ArrayList();

    [SerializeField]
    private string table;
    [SerializeField]
    private int randomNum;

    [SerializeField]
    private int tries = 3;

    private int currentTries = 0;

    void Start()
    {
        currentTries = tries;
        if(table == "molecule_questions"){
            SaveState.firstLevelQuestions = randomNum;
            SaveState.firstLevelTries = tries;
        } else if(table == "image_select_questions"){
            SaveState.secondLevelQuestions += randomNum;
            SaveState.secondLevelTries = tries;
        } else if(table == "image_select_questions_last" || table == "molecule_questions_image"){
            SaveState.thirdLevelQuestions += randomNum;
            SaveState.thirdLevelTries = tries;
        }
        db.table=table;
        IDbConnection con = db.CreateAndOpenDatabase();
        //insert data
        IDataReader reader = db.ReadData(con, table);
        while (reader.Read()) // 17
        {
            Questions.Add(reader.GetString(1));
            Answers.Add(reader.GetString(2));
        }
        
        randomizer(randomNum);
        updateQuestion();
        
        
    }
    
    //if remove parameter is true then we remove the atom from the list
    //else we add it to the list
    public void addOrRemoveAtom(string atom, bool remove)
    {
        if (remove)
        {
            for (int i = 0; i < userAnswer.Count; i++)
            {
                if (userAnswer[i].Equals(atom))
                {
                    userAnswer.RemoveAt(i);
                    break;
                }
            }
        }
        else
        {
            userAnswer.Add(atom);
        }
    }
    
    public void checkAnswers()
    {
        bool isLost = false;
        userAnswer.Sort();
        answer.Sort();
        // foreach(string s in userAnswer){

        //     Debug.Log(s);
        // }

        // Debug.Log("answer: " + answer.Count);
        // foreach(string s in answer){

        //     Debug.Log(s);
        // }
        
        if (answer.Count == userAnswer.Count)
        {
            for (int i = 0; i < answer.Count; i++)
            {
                
                if (!answer[i].Equals(userAnswer[i]))
                {
                    
                    isLost = true;
                    result = changeText("Result", "Incorrect");
                    StartCoroutine(ClearResult(result));
                }
            }
        }
        else
        {
            isLost = true;
            result = changeText("Result", "Incorrect");
            StartCoroutine(ClearResult(result));
        }
        currentTries--;
        
        if(!isLost || currentTries == 0)
        {
            if(!isLost) {
                if(table == "molecule_questions"){
                    SaveState.firstLevel += currentTries + 1;
                    
                    Debug.Log("first level: " + SaveState.firstLevel);
                } else if(table == "image_select_questions"){
                    SaveState.secondLevel += currentTries + 1;
                    Debug.Log("second level: " + SaveState.secondLevel);
                } else if(table == "image_select_questions_last" || table == "molecule_questions_image"){
                    SaveState.thirdLevel += currentTries + 1;
                    Debug.Log("third level: " + SaveState.thirdLevel);
                }
                
                result = changeText("Result", "Correct");
            
            }
            currentTries = tries;
            StartCoroutine(ClearResult(result));
            userAnswer.Clear();
            //clear disable the glow on all that have been selected
            unClick();
            
            Answers.RemoveAt(0);
            Questions.RemoveAt(0);
            if(Answers.Count == 0){
                result = changeText("Result", "Next");
                StartCoroutine(ClearResult(result));
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                return;
            }
            answer = new ArrayList();
            userAnswer = new ArrayList();
            updateQuestion();
        }
        IEnumerator ClearResult(Text result)
        {
            yield return new WaitForSeconds(4f);

            result.text = "";
        }

        Text changeText(string tagName, string message)
        {
            go = GameObject.FindGameObjectWithTag(tagName);
            result = go.GetComponent<Text>();
            result.text = message;

            return result;
        }
    }

    public void unClick(){
        clicked = GameObject.FindGameObjectsWithTag("Clicked");
            foreach(var ob in clicked)
            {
                atomPrefab ap = ob.GetComponent<atomPrefab>();
                if(ap.isGlowing){ 
                    ap.SendMessage("glowOffPrefab");
                    ap.clickCount = -1;
                } else {
                    ap.SendMessage("deselect");
                    ap.clickCount = -1;
                }
            }
    }

    //5 random questions and answers
    public void randomizer(int questionNum){
        ArrayList randomQuestions = new ArrayList();
        ArrayList randomAnswers = new ArrayList();
        ArrayList repeted = new ArrayList();

        for(int i = 0; i < questionNum; i++){
            int random = Random.Range(0, Questions.Count);
            while(repeted.Contains(random)){
                random = Random.Range(0, Questions.Count);
            }
            repeted.Add(random);
            randomQuestions.Add(Questions[random]);
            randomAnswers.Add(Answers[random]);
        }

        Questions = randomQuestions;
        Answers = randomAnswers;
    }


    //For each answer to the question, it parses the answer string into arraylist
    public void updateQuestion(){
       
        questionText.text = Questions[0].ToString();
        foreach(string s in Answers[0].ToString().Split(',')){
            answer.Add(s);
        }
        // Debug.Log("Question: " + questionText.text);
        // foreach(string s in answer){
        //    Debug.Log("Answer: " + s);
        // }
        // Debug.Log("AnswerCount: " + answer.Count);
    }
}
