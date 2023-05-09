using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class robotScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject robotCanvas;
    [SerializeField]
    movement playerMovement;
    void Start()
    {
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position,transform.position) <=20 )
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // SceneManager.LoadScene("robotDialogue");
                playerMovement.enabled = false;
                robotCanvas.SetActive(true);
            }
        }
    }
}
