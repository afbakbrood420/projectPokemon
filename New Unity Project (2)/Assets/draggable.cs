using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rt;
    private GameObject snappingTo;
    private snappable snappingComponent;
    private bool notYetReceivedKey = true;

    public GameObject ParentWhileDragging; //this makes sure that the draggable objects cant be hidden behind the slot
    public int key;

    /*
     * this script makes the object that it is attached to a draggable object.
     * It is designed so that you can't leave the object just somewhere, it always snaps to a snappable object
     */ 


    //this is called right at the start when this object is created
    public void snapTo(GameObject slot) 
    {
        rt.position = slot.transform.position; //move to the slot
        snap(); //snap() gets the closest snappable object, so its an easy way to snap right to an object
    }

    private void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
        ParentWhileDragging = GameObject.FindGameObjectWithTag("draggableObjectRenderer");
        snap();
    }
    
    //this is called on the begginning of the drag motion
    public void OnBeginDrag(PointerEventData eventData)
    {
        snappingTo.SendMessage("onLeaveSnap"); //make sure the other slot apears as free to the new draggable object
        gameObject.transform.SetParent(ParentWhileDragging.transform); //make sure that we are on top of the renderlayer, and not moving while you scroll the bar
    }

    //this is called when the object is being dragged
    public void OnDrag(PointerEventData eventData)
    {
        rt.anchoredPosition += eventData.delta; //move the position of the dragging object with the same amount the mouse moved in all directions.
    }

    //this is called then the object is being released
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("snapping");
        snap();
    }
    void snap()
    {
        //seek the closest snappable Gameobject.
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("snappable"))
        {
            snappingComponent = (item.GetComponent("snappable") as snappable); 

            // if this is the first item in the list, this will trigger and make sure it is not null
            if (snappingTo == null && snappingComponent.free) 
            {
                if(notYetReceivedKey || key == snappingComponent.key){ snappingTo = item; } //checks if the keys are the same
            }

            //checks if the item of the list is closer to the snappingTo, and sets the closer one.
            else if (getDistance(item) < getDistance(snappingTo)&& snappingComponent.free) 
            {
                if (notYetReceivedKey || key == snappingComponent.key) { snappingTo = item; } //make sure that the key is the same as the slot, so you cant crossover moves
            }
        }

        //snap to the closest snappable GameObject, and send it a message that it is occupied.
        if (notYetReceivedKey)
        {
            key = (snappingTo.GetComponent("snappable") as snappable).key; // make sure we get the key
            notYetReceivedKey = false; // make sure we are not swapping keys around
        } 
        rt.position = snappingTo.transform.position; //move to the object to its snappedPosition
        gameObject.transform.SetParent(snappingTo.transform); //setting the parent to the new gameObject so it scrolls in a list, or in animations.
        snappingTo.SendMessage("onSnap", gameObject); //send the slot a message of arrival.
    }
    float getDistance(GameObject target)
    {
        // ((x1-x2)^2+(y1-y2)^2)^0.5 <-- pythagoras formula for the distance 
        return Mathf.Pow(Mathf.Pow(gameObject.transform.position.x-target.transform.position.x, 2) + Mathf.Pow(gameObject.transform.position.y-target.transform.position.y,2),0.5f);
    }
}
