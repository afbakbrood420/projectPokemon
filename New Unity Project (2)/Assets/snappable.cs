using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snappable : MonoBehaviour
{
    public bool free = true;
    public GameObject objectInSlot;
    public GameObject draggableMove;
    public int key; //key for protecting this slot against other pokemon moves. 

    /*
     * this class manages a slot for the move, it deals with key management, showing it as free or occupied, and it can make a move inside this slot.
    */

    void onSnap(GameObject newDraggable) //this function is called by the draggable object
    {
        free = false; //make sure that we can't put 2 objects in 1 slot
        objectInSlot = newDraggable; 
    }
    void onLeaveSnap() //this is also called by the draggable object
    {
        free = true;
        objectInSlot = null;
    }
    void occupyWith(move Move) // this makes the move inside this slot
    {
        Instantiate(draggableMove , transform).SendMessage("setMove", Move);
    }
    //is called by the keymanager and makes sure the key is ready
    void addKey(int newKey)
    {
        key = newKey;
        
    }
    
}
