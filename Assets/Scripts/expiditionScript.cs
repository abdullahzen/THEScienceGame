using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class expiditionScript : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private GameObject resourceButtonToDisable;
    [SerializeField]
    private GameObject moveOnButtonToDisable;
    [SerializeField]
    private GameObject mainTextToDisable;
    [SerializeField]
    private GameObject expiditiontextToEnable;
    [SerializeField]
    private GameObject contigencyButtonToEnable;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        button.SetActive(false);
        resourceButtonToDisable.SetActive(false);
        moveOnButtonToDisable.SetActive(false);
        mainTextToDisable.SetActive(false);
        expiditiontextToEnable.SetActive(true);
        contigencyButtonToEnable.SetActive(true);
    }
}
