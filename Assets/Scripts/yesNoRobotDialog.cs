using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yesNoRobotDialog : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private GameObject noTextToEnable;
    [SerializeField]
    private GameObject yesTextToEnable;
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
        yield return new WaitForSeconds(3);
        if (yesTextToEnable.activeSelf)
        {
            Debug.Log("go to game now");
        }
        if (noTextToEnable.activeSelf)
        {
            Debug.Log("go to main menu");
        }
    }
}
