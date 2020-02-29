using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUpWindow : MonoBehaviour
{
    public Button btn;
    public Text msgText;
    public List<Text> texts = new List<Text> { };
    public List<Image> images = new List<Image> { };

    /*
     * this script is responsable for the pop up window. It makes sure that it shows and hide, displays the message, etc.
    */

    private void Start()
    {
        hideAll();
        btn.onClick.AddListener(hideAll);
    }

    //makes sure all is hidden, this is called when the ok button is pressed
    void hideAll()
    {
        btn.enabled = false;
        foreach (Image image in images)
        {
            image.enabled = false; //when image components are disabled, they dont render
        }
        foreach (Text text in texts)
        {
            text.enabled = false;//the same is true for texts
        }
    }

    //makes sure all is shown
    void showAll()
    {
        btn.enabled = true;
        foreach (Image image in images)
        {
            image.enabled = true;
        }
        foreach (Text text in texts)
        {
            text.enabled = true;
        }
    }

    //this is called by various gameobjects which want to notify the player of something
    public void notification(string msg)
    {
        msgText.text = msg;
        showAll();
    }

}
