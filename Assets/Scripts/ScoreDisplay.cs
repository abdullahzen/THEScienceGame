using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + SaveState.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
