


using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using TMPro;

public class submitButton : MonoBehaviour
{
    private Text result;
    private GameObject go;
    private GameObject[] clicked;

    [SerializeField]
    private TextMeshProUGUI  questionText;
    

    [SerializeField]
    private GameObject dbObj;
    
    private Model db;



    ArrayList userAnswer = new ArrayList();

    ArrayList answer = new ArrayList();

    ArrayList Questions = new ArrayList();
    ArrayList Answers = new ArrayList();

    [SerializeField]
    private string table;
    [SerializeField]
    private string additional;
    void Start()
    {

        db = dbObj.GetComponent<Model>();



        IDbConnection con = connector(table, additional);
        //insert data
        IDataReader reader = db.ReadData(con, table);
        while (reader.Read()) // 17
        {
            Questions.Add(reader.GetString(1));
            Answers.Add(reader.GetString(2));
            // Debug.Log("Question: " + reader.GetString(1) + " Answer " + reader.GetString(2));
        }
        
        randomizer(5);
        
        //for testing
        // for(int i = 0; i < Questions.Count; i++){
        //     Debug.Log(Questions[i] + " " + Answers[i]);
        // }


        updateQuestion();
        
        
        //remove
        
       
        // foreach(string s in answer){

        //     Debug.Log(s);
        // }
        
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
        Debug.Log("User Answer: " + userAnswer.Count);
        foreach(string s in userAnswer){

            Debug.Log(s);
        }

        Debug.Log("answer: " + answer.Count);
        foreach(string s in answer){

            Debug.Log(s);
        }
        
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
            
            Debug.Log("Count");
            isLost = true;
            result = changeText("Result", "Incorrect");
            StartCoroutine(ClearResult(result));
        }
        
        if(isLost == false)
        {
            result = changeText("Result", "Correct");
            StartCoroutine(ClearResult(result));
            userAnswer.Clear();
            //clear disable the glow on all that have been selected
            unClick();
            //change nitric acid to formaldehyde
            //gevorg if you want i guess you can get the question from the db and put it here
            
            //change the answer to the next one
             
            
            Answers.RemoveAt(0);
            Questions.RemoveAt(0);
            if(Answers.Count == 0){
                result = changeText("Result", "You Win");
                StartCoroutine(ClearResult(result));
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
       Debug.Log("Question: " + questionText.text);
        Debug.Log("Answer: " + Answers[0]);
        questionText.text = Questions[0].ToString();
        foreach(string s in Answers[0].ToString().Split(',')){
            answer.Add(s);
        }
        
    }

    public IDbConnection connector(string table, string additional){
        return db.CreateAndOpenDatabase("CREATE TABLE IF NOT EXISTS '"+ table +"' ("
	            + "'id' INTEGER,"
	            + "'Question'	TEXT,"
	            + "'Answer' TEXT,"
                + additional
	            + "PRIMARY KEY('id' AUTOINCREMENT));");
    }

}
