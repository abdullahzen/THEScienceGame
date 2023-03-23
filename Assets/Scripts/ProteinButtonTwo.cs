using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProteinButtonTwo : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    private resourceText rt;
    private Image img1;
    private Image img2;
    private Image img3;
    private Image img4;
    [SerializeField]
    private Sprite protein1;
    [SerializeField]
    private Sprite protein2;
    [SerializeField]
    private Sprite protein3;
    [SerializeField]
    private Sprite protein4;
    // harness button to disable in case its already active
    [SerializeField]
    private GameObject harnessToDisable;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        GameObject txt = GameObject.FindWithTag("ResourceText");
        rt = txt.GetComponent<resourceText>();
        img1 = GameObject.Find("img1").GetComponent<Image>();
        img2 = GameObject.Find("img2").GetComponent<Image>();
        img3 = GameObject.Find("img3").GetComponent<Image>();
        img4 = GameObject.Find("img4").GetComponent<Image>();
    }
    void TaskOnClick()
    {
        harnessToDisable.SetActive(false);
        Color newColor;
        ColorUtility.TryParseHtmlString("#0F4A66", out newColor);
        button.GetComponent<Image>().color = newColor;
        Color imgColor;
        ColorUtility.TryParseHtmlString("#FFFFFF", out imgColor);
        img1.color = imgColor;
        img2.color = imgColor;
        img3.color = imgColor;
        img4.color = imgColor;
        img1.sprite = protein1;
        img2.sprite = protein2;
        img3.sprite = protein3;
        img4.sprite = protein4;
        rt.changeText("Amino acids are the units that make up the proteins, " +
            "and you’ll remember that amino acids differ from carbohydrates and lipids" +
            " in that they also contain a nitrogen atom. Amino acids have a branching " +
            "pattern, where several chemical groups branch off from a central or alpha" +
            " carbon. One of these chemical groups contains a nitrogen atom, another " +
            "includes a carbon attached to oxygens, and a third will differ depending " +
            "on the identity of the amino acid.");

    }
}
