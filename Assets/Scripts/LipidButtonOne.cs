using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LipidButtonOne : MonoBehaviour
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
        rt.changeText("Lipids are composed of smaller components, " +
        "which include fatty acids. Fatty acids are commonly composed of carbon, " +
        "hydrogen and oxygen. The ratio of atoms is unlike that of the carbohydrates, " +
        "as fatty acids have many more carbon and hydrogen atoms than oxygen.");

    }
}
