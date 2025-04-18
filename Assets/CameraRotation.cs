using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public GameObject camera; 

    //bool tiltCamera = true;
    public float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       mouseY = Input.GetAxis("Mouse Y");

        //bug 
        //camera can 360 rotate around frog - use limits to stop? 
        
        //if (Input.mousePosition.y > -0.5 && mouseY < 0.5){
            camera.transform.Rotate(-mouseY, 0f, 0f);

       //}
        
    }
}
