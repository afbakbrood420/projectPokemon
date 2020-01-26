using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addMoves : MonoBehaviour
{
    public GameObject draggableMove;
    public GameObject slot;
    private int key;
    private GameObject buildingSlot;

    /*
    This script makes a draggable object that represents a move for a pokemon. 
    We have a prefabricated object assigned in the editor in the draggable move variable. 
    we can also receive keys in so we can assign them to the moves. The keys represents
    which pokemon the move belongs to, we use it to make sure that you can't cross over the move
    */

    //this function is called from the highest parent of the prefab
    public void addKey(int newKey)
    {
        key = newKey;
    }
    
    //this method gets called from the highest parent of the prefab.
    public void makeMoves(Pokemon pokemon)
    {
        foreach (move Move in pokemon.moves) //pokemon.moves is a list with all the moves for the pokemon
        {
            buildingSlot =  Instantiate(slot, transform); //build the prefab
            buildingSlot.SendMessage("addKey", key); //add a key to the prefab
            buildingSlot.SendMessage("occupyWith", Move); //add the move to the prefab
        }
    }
}
