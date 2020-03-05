using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battlesceneHider : MonoBehaviour
{
    public bool isShown;
    public List<Image> imagesToHide = new List<Image> { };
    public List<Text> textsToHide = new List<Text> { };

    /*
     * dit script zet meerdere texts aan en uit, en images, redelijk simpel
     */

    public void changeVisibility(bool newVisibility)
    {
        foreach (Text text in textsToHide)
        {
            text.enabled = newVisibility;
        }
        foreach (Image image in imagesToHide)
        {
            image.enabled = newVisibility;
        }
        isShown = newVisibility;
    }
}
