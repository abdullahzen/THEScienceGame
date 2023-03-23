using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarbohydrateButtonTwo : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    private resourceText rt;
    private Image img2;
    private Image img3;
    private Image img1;
    private Image img4;
    [SerializeField]
    private Sprite carb1;
    [SerializeField]
    private Sprite carb2;
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
        // changing colour of button once clicked
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
        img2.sprite = carb1;
        img3.sprite = carb2;
        rt.changeText("Remember that monosaccharides make up more complex sugars. " +
            "Monosaccharides relevant to human metabolism share a basic structure, " +
            "a ring or polygonal shape with an oxygen at one of its corners. " +
            "Hexagonal and pentagonal rings are most common");

    }
}
