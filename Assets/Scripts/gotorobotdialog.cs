using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gotorobotdialog : MonoBehaviour
{
    [SerializeField]
    private GameObject yesRobotButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yesRobotButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("go to robot dialogue now");
    }
}
