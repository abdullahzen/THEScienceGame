using System.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI totalScoreText;
    [SerializeField]
    private TextMeshProUGUI firstLevelScoreText;
    [SerializeField]
    private TextMeshProUGUI secondLevelScoreText;
    [SerializeField]
    private TextMeshProUGUI thirdLevelScoreText;
    [SerializeField]
    private TextMeshProUGUI studentIdText;


    // Start is called before the first frame update
    void Start()
    {

        totalScoreText.text = "Score: " + (SaveState.firstLevel + SaveState.secondLevel + SaveState.thirdLevel) 
        + "/" + (SaveState.firstLevelQuestions*SaveState.firstLevelTries + SaveState.secondLevelQuestions*SaveState.secondLevelTries + SaveState.thirdLevelQuestions*SaveState.thirdLevelTries);
        firstLevelScoreText.text = "Level 1: " + SaveState.firstLevel + "/" + SaveState.firstLevelQuestions*SaveState.firstLevelTries;
        secondLevelScoreText.text = "Level 2: " + SaveState.secondLevel + "/" + SaveState.secondLevelQuestions*SaveState.secondLevelTries;
        thirdLevelScoreText.text = "Level 3: " + SaveState.thirdLevel + "/" + SaveState.thirdLevelQuestions*SaveState.thirdLevelTries;

        studentIdText.text = "Student Id: " + SaveState.studentId;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
