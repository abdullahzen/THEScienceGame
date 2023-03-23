using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NucleicAcidButtonOne : MonoBehaviour
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
        rt.changeText("Nucleic acids are composed of smaller biomolecules called " +
        "nucleotides. Nucleotides are composed mainly of carbon, hydrogen, " +
        "oxygen, nitrogen, and phosphorus. Nucleic acids include our genetic " +
        "information, deoxyribonucleic acid, or DNA");

    }
}
