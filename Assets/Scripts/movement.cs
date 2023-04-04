using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{

    public Rigidbody rb;
    float speed = 0.5f;
    private float x;
     private float y;
     private Vector3 rotateValue;


    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {

        //walk forwards
       if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
        transform.Translate(Vector3.forward * speed, Camera.main.transform);
       } 

       
        
        //sprint (zoom the FoV when user wants to sprint)
       if(Input.GetKeyDown(KeyCode.LeftShift)){
        speed += 0.45f;
       }else if(Input.GetKeyUp(KeyCode.LeftShift)){
        speed = 0.5f;
       } 

        //walk backwards
       if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
        transform.Translate(Vector3.forward * -speed, Camera.main.transform);
       }

       //walk Left
       if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
         transform.Translate(Vector3.left * speed, Camera.main.transform);
       }

       //walk right
       if(Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D)){
         transform.Translate(Vector3.left * -speed, Camera.main.transform);
       }

        //restart level
       if(Input.GetKey(KeyCode.Escape)){
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }

        //move camera
          y = Input.GetAxis("Mouse X");
         rotateValue = new Vector3(x, y * -1, 0);
         transform.eulerAngles = transform.eulerAngles - rotateValue;

      

}
}