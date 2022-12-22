using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    [SerializeField]
    private GameObject go;
    void Start()
    {
        
    }

    public void glowOn()
    {
        go.SetActive(true);
    }

    public void glowOff()
    {
        go.SetActive(false);
    }
}
