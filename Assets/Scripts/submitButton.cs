using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class submitButton : MonoBehaviour
{
    private Text result;
    private GameObject go;
    private GameObject[] clicked;
    List<string> userAnswer = new List<string>();
    List<string> answer;
    void Start()
    {
        //gevorg get the answers for nitric acid here
        answer = new List<string>()
        {
            "Hydrogen", "Nitrogen", "Oxygen", "Oxygen", "Oxygen"
        };
    }
    //if remove parameter is true then we remove the atom from the list
    //else we add it to the list
    public void addOrRemoveAtom(string atom, bool remove)
    {
        if (remove)
        {
            for (int i = 0; i < userAnswer.Count; i++)
            {
                if (userAnswer[i] == atom)
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
        if (answer.Count == userAnswer.Count)
        {
            for (int i = 0; i < answer.Count; i++)
            {
                if (answer[i] != userAnswer[i])
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
        
        if(isLost == false)
        {
            result = changeText("Result", "Correct");
            StartCoroutine(ClearResult(result));
            userAnswer.Clear();
            //clear disable the glow on all that have been selected
            clicked = GameObject.FindGameObjectsWithTag("Clicked");
            foreach(var ob in clicked)
            {
                atomPrefab ap = ob.GetComponent<atomPrefab>();
                ap.SendMessage("glowOffPrefab");
            }
            //change nitric acid to formaldehyde
            //gevorg if you want i guess you can get the question from the db and put it here
            result = changeText("Molecule", "Formaldehyde");
            //change the answer to the next one
            //gevorg get the answers for formaldehyde here
            answer = new List<string>()
            {
                "Carbon", "Hydrogen", "Hydrogen", "Oxygen"
            };
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
}
