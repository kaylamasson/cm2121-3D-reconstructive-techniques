using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{


    //variables 
  
    public GameObject inventoryPanel; //where slots will be placed
    public GameObject slotPrefab;
    public int slotCount; //6 slots in inventory
    
    public GameObject[] gamePieces; //3D pieces
    public GameObject[] itemPieces; //2D assets for inventory
    public GameObject[] collectedItems = new GameObject[6]; //items in inventory

    public bool[] correctPieces = {false, false, false, false, false, false}; //update each slot when correct piece is placed 
    public Slot[] slots = new Slot[6]; //inventory slots

    //public int itemIndex; //index of the painting piece collected

    //public Slot slot;
    public int itemsCollected = 0;
    public bool puzzleCorrect = false;

    public int availableSlot = 0;

    public bool roomComplete;
    public GameObject completeText;
    void Start()
    {

      completeText.SetActive(false);

      for (int i=0; i<slotCount; i++){
        slots[i] = Instantiate(slotPrefab, inventoryPanel.transform).GetComponent<Slot>(); //create slots in grid
      }  
    }

    void Update()
    {
      
      if (itemsCollected == 6){

      
        for (int i=0; i<slotCount; i++)
        {
          //Debug.Log(slots[i].currentItem + " " + itemPieces[i]);
          //if (GameObject.ReferenceEquals(slots[i].currentItem, itemPieces[i]))

          //compares image textures to see if puzzle is correct
          if (slots[i].currentItem.GetComponent<RawImage>().texture == itemPieces[i].GetComponent<RawImage>().texture)
          {
            correctPieces[i] = true;
            //Debug.Log("images match " + i);
          } 
          else
          {
            correctPieces[i] = false;
            //Debug.Log("no match " + i);

          }
       }
        

        // for (int i=0; i<correctPieces.Length; i++)
        // {
        //   Debug.Log(correctPieces[i] + "" + (i + 1));

        //   if (correctPieces[i] == true)
        //   {
        //     puzzleCorrect = true;
        //   }
        //   else
        //   {
        //     puzzleCorrect = false;
        //   } 
        // }



        //checks if all elements in array are true
        if (correctPieces.All(x => x == true))
        {
          //if all true
          //room complete!

          roomComplete = true;


          //Debug.Log("Room complete! Well done");
        }


        if (roomComplete)
        {
          completeText.SetActive(true);
        }
        
        
      } 
    }

    public void collectItem(GameObject piece)
    {
      //Debug.Log("item collected");
      collectedItems[itemsCollected] = piece;  
      //Debug.Log("added to inventory");

      addToInventory();
    }

    void addToInventory()
    {

      //if there is an available slot
        if (itemsCollected < collectedItems.Length){
            

            //find first null slot in inventory
            for (int i=0; i < slotCount; i++){
              if (slots[i].currentItem == null){
                availableSlot = i; 
                break;
              }
            }
            //place items from array into slots
            //items are placed into the first available empty slots
            GameObject item = Instantiate(collectedItems[itemsCollected], slots[availableSlot].transform);

            //make item centered to slot
            item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            slots[availableSlot].currentItem = item; //set current item 

            //increase number of items collected
            itemsCollected ++;
        }
    }


    //getters
    public GameObject getGamePieces(int index)
    {
      return gamePieces[index];
    }

    public GameObject getItemPieces(int index)
    {
      return itemPieces[index];
    }

    public int getSlotCount()
    {
      return slotCount;
    }



}
