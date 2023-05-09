using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gotomainButton : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private GameObject txt;
    [SerializeField]
    private GameObject mainText;
    [SerializeField]
    private GameObject resourceButton;
    [SerializeField]
    private GameObject expiditionButton;
    [SerializeField]
    private GameObject moveOnButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        button.SetActive(false);
        txt.SetActive(false);
        mainText.SetActive(true);
        resourceButton.SetActive(true);
        expiditionButton.SetActive(true);
    }
}
