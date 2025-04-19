using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    //menus 
    public GameObject inventory;
    public GameObject controls;
    public GameObject intro;
    public GameObject uiText; 


    public string inventoryKey;
    public string controlsKey; 
    public GameObject player; 
    public Rigidbody rb;

    public RigidbodyConstraints originalConstraints;
    public RigidbodyConstraints newConstraints;
    

    // Start is called before the first frame update
    void Start()
    {

        //disable menu pop-ups from start
        controls.SetActive(false);
        inventory.SetActive(false);

        //intro should be displayed from game start
        intro.SetActive(true); 

        //ui text always active
        uiText.SetActive(true);

        //get player rigidbody to freeze rotation 
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
