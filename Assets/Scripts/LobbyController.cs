using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LobbyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.name == "Capsule")
        {
            Debug.Log("go to next scene now");
        }
        //SceneManager.LoadScene("ShipChosing");
        //SceneManager.UnloadSceneAsync("lobby");
    }
}
