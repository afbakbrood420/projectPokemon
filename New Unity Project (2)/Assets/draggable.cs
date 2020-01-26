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

    public GameObject ParentWhileDragging; //dit doen we zodat je de moves niet achter de slots kan schuiven.
    public int key;

    public void snapTo(GameObject slot)
    {
        rt.position = slot.transform.position;
        snap();
    }

    private void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
        ParentWhileDragging = GameObject.FindGameObjectWithTag("draggableObjectRenderer");
        snap();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        snappingTo.SendMessage("onLeaveSnap"); //make sure the other slot apears as free to the new draggable object
        gameObject.transform.SetParent(ParentWhileDragging.transform); //make sure that we are on top of the renderlayer, and not moving while you scroll the bar
        return; 
    }

    public void OnDrag(PointerEventData eventData)
    {
        rt.anchoredPosition += eventData.delta; //move the position of the dragging object with the same amount the mouse moved in all directions.
    }

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
            if (snappingTo == null && snappingComponent.free)
            {
                if(notYetReceivedKey || key == snappingComponent.key){ snappingTo = item; } 
            }
            // if this is the first item in the list, this will trigger and make sure it is not null

            else if (getDistance(item) < getDistance(snappingTo)&& snappingComponent.free) //checks if the item of the list is closer to the snappingTo, and sets the closer one.
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
