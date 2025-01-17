using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtomButton : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    private resourceText rt;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        GameObject txt = GameObject.FindWithTag("ResourceText");
        rt = txt.GetComponent<resourceText>();
    }
    void TaskOnClick()
    {
        Color newColor;
        ColorUtility.TryParseHtmlString("#0F4A66", out newColor);
        button.GetComponent<Image>().color = newColor;
        rt.changeText("Life�s macromolecules are mainly composed of the following atoms: " +
        "carbon (C), hydrogen (H), oxygen (O), and nitrogen (N). " +
        "These atoms make up 96% of humans. The remaining 4% is mostly accounted " +
        "for by calcium (Ca), phosphorus (P), potassium (K), sulfur (S), sodium (Na), " +
        "chlorine (Cl), and magnesium (Mg).");
            
    }
}
