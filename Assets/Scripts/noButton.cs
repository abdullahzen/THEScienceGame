using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noButton : MonoBehaviour
{
    private Button btn;
    [SerializeField]
    private GameObject noBtn;
    [SerializeField]
    private GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        btn = noBtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        // set text active
        text.SetActive(true);
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
