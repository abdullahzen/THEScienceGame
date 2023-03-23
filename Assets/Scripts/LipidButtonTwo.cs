using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LipidButtonTwo : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    private resourceText rt;
    private Image img1;
    private Image img2;
    private Image img3;
    private Image img4;
    [SerializeField]
    private Sprite lipid1;
    [SerializeField]
    private Sprite lipid2;
    [SerializeField]
    private Sprite lipid3;
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
        Color noPicColor;
        ColorUtility.TryParseHtmlString("#000000", out noPicColor);
        ColorUtility.TryParseHtmlString("#FFFFFF", out imgColor);
        img1.color = imgColor;
        img2.color = imgColor;
        img3.color = imgColor;
        img4.color = noPicColor;
        img1.sprite = lipid1;
        img2.sprite = lipid2;
        img3.sprite = lipid3;
        rt.changeText("Remember that some larger lipids are composed of fatty acids," +
            " and fatty acids are composed of a long string of carbons, or a linear " +
            "chain of carbons. This chain of carbons can be long or short, straight" +
            " or curved, and typically contains oxygens at one end of the long chain.");

    }
}
