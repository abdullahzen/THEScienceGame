using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goOnTwo : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
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
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        GameObject txt = GameObject.FindWithTag("ResourceText");
        rt = txt.GetComponent<resourceText>();
        button = GameObject.Find("goOn2");
    }

    void TaskOnClick()
    {
        // enable back bottom buttons
        carbButtonToDisable.SetActive(true);
        carbonButtonToDisable.SetActive(true);
        lipidButtonToDisable.SetActive(true);
        proteinButtonToDisable.SetActive(true);
        nucleicAcidButtonToDisable.SetActive(true);
        button.SetActive(false);
        rt.changeText("Again, I�m impressed by your interest in chemistry. Other captains" +
            " I�ve served are content enough to identify the biomolecules and collect the" +
            " right resources to fuel the ship, but you seem interested beyond that. I " +
            "figure I should reward your curiosity, so choose what you�d like.� *Sorry no " +
            "rewards have been added to the game yet");
    }
}
