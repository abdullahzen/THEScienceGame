using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarbonSkeleton : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private GameObject harnessButtonToEnable;
    private resourceText rt;
    private Image img1;
    private Image img2;
    private Image img3;
    private Image img4;
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
        Color newColor;
        ColorUtility.TryParseHtmlString("#0F4A66", out newColor);
        button.GetComponent<Image>().color = newColor;
        Color noPicColor;
        ColorUtility.TryParseHtmlString("#000000", out noPicColor);
        img1.color = noPicColor;
        img2.color = noPicColor;
        img3.color = noPicColor;
        img4.color = noPicColor;
        harnessButtonToEnable.SetActive(true);
        rt.changeText("Interestingly enough, because carbon can form four separate" +
            " bonds with other atoms, carbons help form the framework or skeleton of " +
            "the biomolecules. Carbons can form single bonds, double bonds, and triple" +
            " bonds as well. This ability helps create the different shapes of the " +
            "biomolecules, long linear chains, ring shapes, large branching structures," +
            " and even hybrids of all three of these shapes. Metabolizing nutrients commonly " +
            "involves breaking these bonds and harnessing the energy that’s released");
            
    }
}
