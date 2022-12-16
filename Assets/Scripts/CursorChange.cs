using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorChange : MonoBehaviour
{
   
    [SerializeField]
    private GameObject cursor;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
    }
   
    
    //raw image following the mouse
    void Update()
    {
        
        cursor.transform.position = Input.mousePosition;
    }
}
