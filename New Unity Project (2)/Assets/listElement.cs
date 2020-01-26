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

    public void deselect()
    {
        img.color =  new Color(255,255,255,130);
    }
    public void select()
    {
        img.color = selectedColor;
    }
    void requestSelect()
    {
        listmanager.SendMessage("changeSelectedPokemon", pokemonIndex);
    }
}
