using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enterStudentId : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private InputField studentIdInput;
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        studentIdInput = studentIdInput.GetComponent<InputField>();
    }

    void TaskOnClick()
    {
        // fetch input field
        string idToSend = studentIdInput.text;
        // save it in savestate
        SaveState.studentId = idToSend;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
