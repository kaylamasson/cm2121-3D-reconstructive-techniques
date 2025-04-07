using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{

    public GameObject inventoryPanel; //where slots will be placed
    public GameObject slotPrefab;
    public int slotCount;
    
    public GameObject[] gamePieces; //3D pieces
    public GameObject[] itemPieces; //2D assets for inventory
    public GameObject[] collectedItems = new GameObject[6]; //items in inventory

    public bool[] correctPieces = {false, false, false, false, false, false}; 
    public Slot[] slots = new Slot[6];
    //public int itemIndex; //index of the painting piece collected

    //public Slot slot;
    public int itemsCollected = 0;
    public bool puzzleCorrect = false;


    void Start()
    {

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
        Debug.Log("Room complete! Well done");
        }
        
        
      } 
    }

    public void collectItem(GameObject piece)
    {
      //Debug.Log("item collected");
      collectedItems[itemsCollected] = piece; //problem 
      //Debug.Log("added to inventory");

      addToInventory();
    }

    void addToInventory()
    {

      //if there is an available slot
        if (itemsCollected < collectedItems.Length){

            //place items from array into slots
            GameObject item = Instantiate(collectedItems[itemsCollected], slots[itemsCollected].transform);

            //make item centered to slot
            item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            slots[itemsCollected].currentItem = item; //set current item 

            itemsCollected ++;
        }
    }

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
