using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bewegingsemulgator : MonoBehaviour
    
{
    public float speed = 5.0f;
    //Snelheid van de speler.
 
    public Transform walkDirection;
    //Geeft het punt aan waar de player naar gaat lopen.

    public LayerMask blockDetector;
    //Eigenschap van walkDirection, checkt of er iets staat waar hij niet mag komen, bijvootbeeld muren.

    void Start()
    //Wat de computer bij het opstarten moet laden / uitvoeren.
    {
        
    }

    
    private void FixedUpdate()
    // Update het programma een aantal keer per seconde
    {
        transform.position = Vector3.MoveTowards(transform.position, walkDirection.position, speed * Time.deltaTime);
        //Geeft directie en snelheid aan waarmee hij naar het punt gaat waar hij toe gaat lopen, met de snelheid. Transform.position is de positie van de speler, walkDirection.position is het punt waar hij naartoe gaat, en speed * Time.deltaTime zorgt voor de snelheid.

        if (Vector3.Distance(transform.position, walkDirection.position) <= 0.2f)
        {

            if ((Input.GetAxisRaw("Horizontal")) == 1f || (Input.GetAxisRaw("Horizontal") == -1f))
            {
                walkDirection.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
            else if ((Input.GetAxisRaw("Vertical")) == 1f || (Input.GetAxisRaw("Vertical") == -1f))
            {
                walkDirection.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
        }
    }
}
