using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class yesNoRobotDialog : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private GameObject noTextToEnable;
    [SerializeField]
    private GameObject yesTextToEnable;
    [SerializeField]
    private Button yesButton;
    [SerializeField]
    private Button noButton;
    [SerializeField]
    private GameObject closingCanvas;
    [SerializeField]
    private movement playerMovement;
        // Start is called before the first frame update

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(delegate {TaskOnClick(button.name); });
    }

    void TaskOnClick(string name)
    {
        if(name == "yesButton")
        {
            yesTextToEnable.SetActive(true);
            StartCoroutine(nextSceneCoroutine());
        }
        else
        {
            noTextToEnable.SetActive(true);
            StartCoroutine(nextSceneCoroutine());
        }
    }

    IEnumerator nextSceneCoroutine()
    {
        yesButton.interactable = false;
        noButton.interactable = false;
        yield return new WaitForSeconds(3);
        if (yesTextToEnable.activeSelf)
        {
            closingCanvas.SetActive(false);
            playerMovement.enabled = true;
            yesTextToEnable.SetActive(false);
        }
        if (noTextToEnable.activeSelf)
        {
            closingCanvas.SetActive(false);
            playerMovement.enabled = true;
            noTextToEnable.SetActive(false);
        }
        yesButton.interactable = true;
        noButton.interactable = true;
        
        
    }
}
