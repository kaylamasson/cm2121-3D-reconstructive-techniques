using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    // to implement the draggable items feature, I 
    // used the following YouTube video as a reference: 
    // https://www.youtube.com/watch?v=wlBJ0yZOYfM&list=PLaaFfzxy_80HtVvBnpK_IjSC8_Y9AOhuP&index=9
    

    public Transform originalParent;
    public CanvasGroup canvasGroup;

    public AudioSource dropSound;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       originalParent = transform.parent;  //save original parent
       transform.SetParent(transform.root); //above any other canvases
       canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; //follow mouse position
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        //play sound effect
        dropSound.Play();

        canvasGroup.blocksRaycasts = true; //enables raycasts - clickable
        
        Slot dropSlot = eventData.pointerEnter?.GetComponent<Slot>(); //slot where item dropped
        
        if (dropSlot == null)

        //if not empty slot
        {
            GameObject item = eventData.pointerEnter; 
            if (item != null)
            {
                //if there is an item in the slot
                //set target slot to the slot the item is in
                dropSlot = item.GetComponentInParent<Slot>();
            }
        }
        
        Slot originalSlot = originalParent.GetComponent<Slot>();

        if (dropSlot != null)
        {
            //if there is a slot under mouse pointer
            if (dropSlot.currentItem != null){ //if target slot has an item in it
                dropSlot.currentItem.transform.SetParent(originalSlot.transform); //set target slot's item parent to other slot
                originalSlot.currentItem = dropSlot.currentItem; //change item occupied in original slot
                dropSlot.currentItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; //snaps item to center of slot
            }
            else 
            {
                originalSlot.currentItem = null; //original slot will be empty if target slot was originally empty
            }

            transform.SetParent(dropSlot.transform); //set item parent to target slot
            dropSlot.currentItem = gameObject; //set the target slot's current item to this (dragged) item       
        }
        else
        {
            //if there is no slot under mouse pointer
            transform.SetParent(originalParent); //set position back to original slot
        }

        GetComponent<RectTransform>().anchoredPosition = Vector2.zero; //center item in slot

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
