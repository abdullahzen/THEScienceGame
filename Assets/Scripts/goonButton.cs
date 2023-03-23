using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goonButton : MonoBehaviour
{
    private Button btn;
    // properties to disable
    private GameObject txtToDisable;
    private GameObject researchManToDisable;
    [SerializeField]
    private GameObject buttonToDisable;
    // properties to enable
    [SerializeField]
    private GameObject researchManToEnable;
    [SerializeField]
    private GameObject txtToEnable;
    [SerializeField]
    private GameObject carbButtonToDisable;
    [SerializeField]
    private GameObject lipidButtonToEnable;
    [SerializeField]
    private GameObject proteinButtonToEnable;
    [SerializeField]
    private GameObject nucleicButtonToEnable;
    [SerializeField]
    private GameObject carbonButtonToEnable;
    [SerializeField]
    private GameObject nextSceneButtonToEnable;
    [SerializeField]
    private GameObject img1ToEnable;
    [SerializeField]
    private GameObject img2ToEnable;
    [SerializeField]
    private GameObject img3ToEnable;
    [SerializeField]
    private GameObject img4ToEnable;
    // Start is called before the first frame update
    void Start()
    {
        btn = buttonToDisable.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        // initalizing all components
        txtToDisable = GameObject.Find("text1");
        researchManToDisable = GameObject.Find("researchMan1");
        buttonToDisable = GameObject.Find("goOn");
    }

    void TaskOnClick()
    {
        // disable current stuff
        txtToDisable.SetActive(false);
        researchManToDisable.SetActive(false);
        buttonToDisable.SetActive(false);
        // enable new UI stuff
        researchManToEnable.SetActive(true);
        txtToEnable.SetActive(true);
        carbButtonToDisable.SetActive(true);
        lipidButtonToEnable.SetActive(true);
        proteinButtonToEnable.SetActive(true);
        nucleicButtonToEnable.SetActive(true);
        carbonButtonToEnable.SetActive(true);
        nextSceneButtonToEnable.SetActive(true);
        img1ToEnable.SetActive(true);
        img2ToEnable.SetActive(true);
        img3ToEnable.SetActive(true);
        img4ToEnable.SetActive(true);
    }
}
