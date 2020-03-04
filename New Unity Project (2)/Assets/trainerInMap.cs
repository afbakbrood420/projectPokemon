using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainerInMap : MonoBehaviour
{
    public Trainer trainer;
    private party Party;
    private void Start()
    {
        Party = GameObject.FindObjectOfType<party>();
    }
    public void battle()
    {
        Party.startFight(trainer);
    }
}
