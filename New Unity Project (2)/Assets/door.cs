using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Transform otherSide;
    public trainerInMap trainer;

    public bool isOpen()
    {
        //checks if the trainer is beaten, if so open else its closed
        return trainer.hasBeenBeaten;
    }

}
