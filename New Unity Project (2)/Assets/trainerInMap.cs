using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainerInMap : MonoBehaviour
{
    public Trainer trainer;
    public bool hasBeenBeaten;
    private party Party;
    private void Start()
    {
        Party = GameObject.FindObjectOfType<party>();
        if (Party.trainersDefeated.Contains(trainer))
        {
            hasBeenBeaten = true;
        }
    }
    public void battle()
    {
        if (hasBeenBeaten == false)
        {
            Party.startFight(trainer);
        }
    }
}


