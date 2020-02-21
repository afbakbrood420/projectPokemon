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

    public party pokemonparty;


    // public rekemachine;
    //stats
    //types
    // speed ourpok == speed enemypok; then random int


    public battlesceneHider longmoves;
    public battlesceneHider fbpr;


    void Start()
    {
        //toevoegen van de pokemonparty
        pokemonparty = (GameObject.FindWithTag("party").GetComponent<party>() as party);

        // aanroepen van player spirte
        Ourpoksprite.sprite = pokemonparty.pokemons[0].sprite;

        //aamroepen van enemysprite
        Enemypoksprite.sprite = pokemonparty.trainer.pokemons[0].sprite;

        //Ourpokname house in the middle of our house in the middle of our hosue in the middle of ouhrse ouin dht emidel or four house in th emiddle of lour house in th midlle ouf hioeus on i t hemipi ldle ohunse. 
        // als of fight, dan fight - hide en long moves - show.


        FightButton.onClick.AddListener(Fightbuttonfunction);
        longmoves.changeVisibility(false);


    }

    void Fightbuttonfunction()
    {
        longmoves.changeVisibility(true);
        fbpr.changeVisibility(false);

    }

    void Update()
    {
        
    }
}
