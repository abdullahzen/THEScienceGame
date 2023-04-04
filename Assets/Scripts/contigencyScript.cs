using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contigencyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private GameObject textToDisable;
    [SerializeField]
    private GameObject textToEnable;
    [SerializeField]
    private GameObject buttonToEnable;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        button.SetActive(false);
        textToDisable.SetActive(false);
        textToEnable.SetActive(true);
        buttonToEnable.SetActive(true);
    }
}
