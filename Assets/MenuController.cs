using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{


    public GameObject inventory;
    public GameObject controls;


    public string inventoryKey;
    public string controlsKey; 
    public GameObject player; 
    public Rigidbody rb;

    public RigidbodyConstraints originalConstraints;
    public RigidbodyConstraints newConstraints;
    

    // Start is called before the first frame update
    void Start()
    {

        //disable menu canvas from start
        controls.SetActive(false);
        inventory.SetActive(false);
        rb = player.GetComponent<Rigidbody>();
        originalConstraints = rb.constraints;
    }

    // Update is called once per frame
    void Update()
    {
       //open menu when tab is pressed

       if (Input.GetKeyDown(inventoryKey) && controls.activeInHierarchy == false){
            //Debug.Log("menu key pressed");
            if (inventory.activeInHierarchy == true){
                inventory.SetActive(false);
                rb.constraints = originalConstraints; //resets player rotation to normal once menu is closed
            } else {
                inventory.SetActive(true);
                rb.constraints = RigidbodyConstraints.FreezeRotation; //freezes player rotation when menu is open
            }
       }


       if (Input.GetKeyDown(controlsKey) && inventory.activeInHierarchy == false){
            if (controls.activeInHierarchy == true){
                controls.SetActive(false);
            } else {
                controls.SetActive(true); 
            }
       }
    }
}
