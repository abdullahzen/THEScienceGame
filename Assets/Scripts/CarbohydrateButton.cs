using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarbohydrateButton : MonoBehaviour
{
    [SerializeField]
    private Button carbBut;
    private resourceText rt;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = carbBut.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        GameObject txt = GameObject.FindWithTag("ResourceText");
        rt = txt.GetComponent<resourceText>();
    }
    void TaskOnClick()
    {
        rt.changeText("Carbohydrates are composed of smaller biomolecules called " +
            "monosaccharides.These are commonly composed of carbon, hydrogen and oxygen " +
            "in fixed ratios of 1:2:1. For example, glucose has a chemical formula of" +
            " C6H12O6.");

    }
}
