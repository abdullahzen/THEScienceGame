using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProteinButton : MonoBehaviour
{
    [SerializeField]
    private Button proteinBut;
    private resourceText rt;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = proteinBut.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        GameObject txt = GameObject.FindWithTag("ResourceText");
        rt = txt.GetComponent<resourceText>();
    }
    void TaskOnClick()
    {
        rt.changeText("Proteins are composed of smaller biomolecules called " +
            "amino acids. Amino acids are composed mainly of carbon, hydrogen, " +
            "oxygen, and nitrogen. Proteins can twist and fold themselves to form " +
            "active molecules that perform special functions in cells.");

    }
}
