using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class Battle_Script : MonoBehaviour
{


    [Header("Sprites")]
    public Image Ourpoksprite;
    public Image Enemypoksprite;

    [Header("voor later")]
    public displayBar dbOurpok;
    public displayBar dbEnemypok;
    public Text Eventtekst;
    
    [Header("FBPR")]
    public Button FightButton;
    public Button BagButton;
    public Button PokemonButton;
    public Button RunButton;

    [Header("Moves")]
    public Button Move1;
    public Button Move2;
    public Button Move3;
    public Button Move4;

    [Header("pokname")]
    public Text Ourpokname;
    public Text Enemypokname;

    // pp toevoegen
    [Header("PP + type")]
    public Text PP;
    public Text Type;


    



    // public rekemachine;
    //stats
    //types
    // speed ourpok == speed enemypok; then random int


    void Start()
    {
        
    }

 
    void Update()
    {
        
    }
}
