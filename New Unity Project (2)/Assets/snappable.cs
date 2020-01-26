using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snappable : MonoBehaviour
{
    public bool free = true;
    public GameObject objectInSlot;
    public GameObject draggableMove;
    public int key; //key for protecting this slot against other pokemon moves. 

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag != "snappable")
        {
            Destroy(this); //if something went wrong in the editor, just in case.
        }
    }

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
    void occupyWith(move Move) // this is to make the movelist, which you can choose moves from.
    {
        Instantiate(draggableMove , transform).SendMessage("setMove", Move);
    }
    void addKey(int newKey)
    {
        key = newKey;
    }
    
}
