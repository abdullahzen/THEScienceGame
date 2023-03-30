using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yesButton : MonoBehaviour
{
    private Button btn;
    [SerializeField]
    private GameObject yesBtn;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject sorryText;
    // Start is called before the first frame update
    void Start()
    {
        btn = yesBtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        // set text active
        text.SetActive(true);
        sorryText.SetActive(true);
        // start coroutine
        StartCoroutine(nextSceneCoroutine());
    }

    IEnumerator nextSceneCoroutine()
    {
        Debug.Log("go to wtv scene is next in 5 seconds");
        yield return new WaitForSeconds(5);
        Debug.Log("in next scene now");
    }
}
