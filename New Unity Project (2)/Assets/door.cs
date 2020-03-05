using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Transform otherSide;
    public trainerInMap trainer;

    //slaat de trainer op voor andere scripts om te kijken of hij open is, ook slaat het een punt op waar de deur naartoe gaat

    public bool isOpen()
    {
        //checks if the trainer is beaten, if so open else its closed
        return trainer.hasBeenBeaten;
    }

}
