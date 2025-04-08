using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{


    public GameObject menuCanvas;

    public string menuKey; 
    public GameObject player; 
    public Rigidbody rb;

    public RigidbodyConstraints originalConstraints;
    public RigidbodyConstraints newConstraints;

    // Start is called before the first frame update
    void Start()
    {

        //disable menu canvas from start
        
        menuCanvas.SetActive(false);
        rb = player.GetComponent<Rigidbody>();
        originalConstraints = rb.constraints;
    }

    // Update is called once per frame
    void Update()
    {
       //open menu when tab is pressed

       if (Input.GetKeyDown(menuKey)){
            //Debug.Log("menu key pressed");
            if (menuCanvas.activeInHierarchy == true){
                menuCanvas.SetActive(false);
                rb.constraints = originalConstraints; //resets player rotation to normal once menu is closed
            } else {
                menuCanvas.SetActive(true);
                rb.constraints = RigidbodyConstraints.FreezeRotation; //freezes player rotation when menu is open
            }
       }
    }
}
