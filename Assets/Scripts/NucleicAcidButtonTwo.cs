using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NucleicAcidButtonTwo : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    private resourceText rt;
    private Image img2;
    private Image img3;
    private Image img1;
    private Image img4;
    [SerializeField]
    private Sprite nucleicacid1;
    [SerializeField]
    private Sprite nucleicacid2;
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
        img2 = GameObject.Find("img2").GetComponent<Image>();
        img3 = GameObject.Find("img3").GetComponent<Image>();
        img1 = GameObject.Find("img1").GetComponent<Image>();
        img4 = GameObject.Find("img4").GetComponent<Image>();
    }
    void TaskOnClick()
    {
        harnessToDisable.SetActive(false);
        Color newColor;
        ColorUtility.TryParseHtmlString("#0F4A66", out newColor);
        button.GetComponent<Image>().color = newColor;
        Color imgColor;
        Color noPicColor;
        ColorUtility.TryParseHtmlString("#000000", out noPicColor);
        ColorUtility.TryParseHtmlString("#FFFFFF", out imgColor);
        img2.color = imgColor;
        img3.color = imgColor;
        img1.color = noPicColor;
        img4.color = noPicColor;
        img2.sprite = nucleicacid1;
        img3.sprite = nucleicacid2;
        rt.changeText("Nucleotides are components of much larger molecules called" +
            " nucleic acids. Nucleotides are typically larger than the other three " +
            "biomolecules as they contain three components: a pentagonal sugar, a " +
            "group containing a phosphorus atom, and a ring group containing nitrogen" +
            " atoms. Sometimes the ring group is a single hexagon ring, sometimes it’s" +
            " a double ring made up of a pentagon and a hexagon.");

    }
}
