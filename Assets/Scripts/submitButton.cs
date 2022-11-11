using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class submitButton : MonoBehaviour
{
    string[] userAnswer = new string[5];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void user(string atom)
    {
        for (int i = 0; i < userAnswer.Length; i++)
        {
            if (userAnswer[i] == null)
            {
                userAnswer[i] = atom;
                break;
            }
        }

    }
    public void checkAnswers()
    {
        bool isLost = false;
        List<string> answer = new List<string>()
        {
             "hydrogen", "nitrogen", "oxygen", "oxygen", "oxygen"
        };
        List<string> user = new List<string>(userAnswer);
        user.Sort();
        for (int i = 0; i < answer.Count; i++)
        {
            if (answer[i] != user[i])
            {
                isLost = true;
                Debug.Log("answer is incorrect");
            }
        }
        if(isLost == false)
        {
            Debug.Log("you won");
        }
    }
}
