using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainerInMap : MonoBehaviour
{
    public Trainer trainer;
    public bool hasBeenBeaten;
    private party Party;

    /*
     * this script stores a trainer in an object in the map. So you can Identify which puppet is which trainer
     */

    private void Start() //checks if this trainer has been beaten.
    {
        Party = GameObject.FindObjectOfType<party>();
        if (Party.trainersDefeated.Contains(trainer))
        {
            hasBeenBeaten = true;
        }
    }
    public void battle() //wont start a fight when the trainer is beaten
    {
        if (hasBeenBeaten == false)
        {
            Party.startFight(trainer);
        }
    }
}


