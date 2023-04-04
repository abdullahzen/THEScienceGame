using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    void Start()
    {
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position,transform.position) <=20 )
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("robot dialogueeee");
            }
        }
    }
}
