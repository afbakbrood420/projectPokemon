using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class listElement : MonoBehaviour
{
    // Start is called before the first frame update
    public Image img;
    public Button btn;
    public Text txt;
    public int pokemonIndex;

    private Color selectedColor;
    private GameObject listmanager;
    
    /*
     * this is in collaboration with the listmanager, responsible for the list and the ability to interact with them
    */

    void Start()
    {
        listmanager = transform.parent.gameObject;
        img = gameObject.GetComponent<Image>();
        selectedColor = img.color;
        btn.onClick.AddListener(requestSelect);
        deselect();
    }

    public void setText(string text , int newIndex)
    {
        txt.text = text;
        pokemonIndex = newIndex;
        //Debug.Log(newIndex.ToString());
    }

    //this is called by the manager so is the next method
    public void deselect()
    {
        img.color =  new Color(255,255,255,130);
    }
    public void select()
    {
        img.color = selectedColor;
    }

    //this is called when the button is pressed
    void requestSelect()
    {
        listmanager.SendMessage("changeSelectedPokemon", pokemonIndex); 
    }
}
