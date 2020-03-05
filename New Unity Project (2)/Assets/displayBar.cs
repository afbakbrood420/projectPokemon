using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayBar : MonoBehaviour
{
    public Slider stretchingRt; 
    public Image rearImg;
    public float value = 0.75f; //must be between 0 and 1

    /*
     * dit object is verantwoordelijk voor de controll van de displaybar;
     * het verzet de displaybar elk frame
     */

    private void Update() //is called each frame
    {
        stretchingRt.value = value; //stretching rt is een slider, dat is een geimplementeerde class van unity en kan uitbreiden en ver
        //-kleinen
    }
    //zorgt ervoor dat alles onzichtbaar kan worden
    public void visibility(bool visible)
    {
        stretchingRt.gameObject.SetActive(visible);
        rearImg.enabled = visible;
    }
}
