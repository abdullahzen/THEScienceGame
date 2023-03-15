using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LipidButton : MonoBehaviour
{
    [SerializeField]
    private Button lipidBut;
    private resourceText rt;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = lipidBut.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        GameObject txt = GameObject.FindWithTag("ResourceText");
        rt = txt.GetComponent<resourceText>();
    }
    void TaskOnClick()
    {
        rt.changeText("Lipids are composed of smaller components, " +
            "which include fatty acids. Fatty acids are commonly composed of carbon, " +
            "hydrogen and oxygen. The ratio of atoms is unlike that of the carbohydrates, " +
            "as fatty acids have many more carbon and hydrogen atoms than oxygen.");

    }
}
