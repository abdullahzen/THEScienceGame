using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goOnThree : MonoBehaviour
{
    private Button btn;
    //components to disable
    private GameObject txtToDisable;
    private GameObject researchManToDisable;
    [SerializeField]
    private GameObject buttonToDisable;
    //components to enable
    [SerializeField]
    private GameObject researchManToEnable;
    [SerializeField]
    private GameObject textToEnable;
    [SerializeField]
    private GameObject yesButton;
    [SerializeField]
    private GameObject noButton;
    // Start is called before the first frame update
    void Start()
    {
        btn = buttonToDisable.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        txtToDisable = GameObject.Find("text1");
        researchManToDisable = GameObject.Find("researchMan1");
    }

    void TaskOnClick()
    {
        // disable current stuff
        txtToDisable.SetActive(false);
        researchManToDisable.SetActive(false);
        buttonToDisable.SetActive(false);
        // enable current stuff
        researchManToEnable.SetActive(true);
        textToEnable.SetActive(true);
        yesButton.SetActive(true);
        noButton.SetActive(true);
    }
}
