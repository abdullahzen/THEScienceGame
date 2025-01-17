using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarnessButton : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonToDisable;
    [SerializeField]
    private GameObject buttonToEnable;
    private resourceText rt;
    [SerializeField]
    private GameObject carbButtonToDisable;
    [SerializeField]
    private GameObject carbonButtonToDisable;
    [SerializeField]
    private GameObject lipidButtonToDisable;
    [SerializeField]
    private GameObject proteinButtonToDisable;
    [SerializeField]
    private GameObject nucleicAcidButtonToDisable;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = buttonToDisable.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        GameObject txt = GameObject.FindWithTag("ResourceText");
        rt = txt.GetComponent<resourceText>();
        buttonToDisable = GameObject.Find("HarnessEnergyButton");
    }

    void TaskOnClick()
    {
        // harness energy button and bottom buttons disapears 
        buttonToDisable.SetActive(false);
        carbButtonToDisable.SetActive(false);
        carbonButtonToDisable.SetActive(false);
        lipidButtonToDisable.SetActive(false);
        proteinButtonToDisable.SetActive(false);
        nucleicAcidButtonToDisable.SetActive(false);
        // move on button pops up
        buttonToEnable.SetActive(true);
        rt.changeText("For example, our cells break down sugar in a process called " +
            "cellular respiration. This process creates molecular fuel our cells use to " +
            "perform various activities, like moving around, making new proteins, and " +
            "contracting muscles. The energy stored in the bonds between carbon and other" +
            " atoms can help create this fuel. Our cells not only use sugar but lipids and" +
            " proteins as well since these also contain carbon bonds.");

    }
}

