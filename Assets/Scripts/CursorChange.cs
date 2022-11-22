using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursor;
    [SerializeField]
    private TextAsset imageAsset;
    // Start is called before the first frame update
    void Start()
    {
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(imageAsset.bytes);
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
