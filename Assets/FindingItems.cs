using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindingItems : MonoBehaviour
{

    private int piecesFound = 0; 
    public InventoryController inventory;

    
    //public GameObject[] collectedItems = new GameObject[6]; //pieces collected - inventory

    // Start is called before the first frame update
    void Start()
    {

     inventory = GameObject.Find("GameController").GetComponent<InventoryController>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider collider){

        //if player touches a painting piece 

        if (collider.gameObject.tag == "Painting"){
            //Debug.Log("Piece found!");
            piecesFound ++; 
            //Debug.Log("You have - " + piecesFound + " - pieces.");

            //find piece in item array

            for (int i=0; i<inventory.getSlotCount(); i++)
            {
                //search array to find exact piece picked up
                if (GameObject.ReferenceEquals(inventory.getGamePieces(i), collider.gameObject))
                {
                    //Debug.Log("piece matches");
                    //add item to inventory
                    //collectedItems[collectedItems.Length] = itemPieces[i];
                    inventory.collectItem(inventory.getItemPieces(i));

                    //Debug.Log("item collected");
                    break;
                }
            }
            //use index to find matching 2D item
            //add corresponding item to the collected items array
            

            //destroy game object once found
            Destroy(collider.gameObject);
        }
    }
}
