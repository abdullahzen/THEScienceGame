using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class resourceText : MonoBehaviour
{
    private TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        txt  = GameObject.FindWithTag("ResourceText").GetComponent<TextMeshProUGUI>();
    }

    public void changeText(string text_passed)
    {
        txt.text = text_passed;
    }
}
