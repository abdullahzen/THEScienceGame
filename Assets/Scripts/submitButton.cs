using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class submitButton : MonoBehaviour
{
    List<string> userAnswer = new List<string>();

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
        List<string> answer = new List<string>()
        {
             "Hydrogen", "Nitrogen", "Oxygen", "Oxygen", "Oxygen"
        };
        //List<string> user = new List<string>(userAnswer);
        userAnswer.Sort();
        /*foreach( var x in userAnswer)
        {
            Debug.Log(x);
        }*/
        if (answer.Count == userAnswer.Count)
        {
            for (int i = 0; i < answer.Count; i++)
            {
                if (answer[i] != userAnswer[i])
                {
                    isLost = true;
                    Debug.Log("answer is incorrect");
                }
            }
        }
        else
        {
            isLost = true;
            Debug.Log("answer is incorrect");
        }
        
        if(isLost == false)
        {
            Debug.Log("you won");
            userAnswer.Clear();
            //move on
        }
    }
}
