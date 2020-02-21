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
    public Button backbutton;
    public Text move1;
    public Text move2;
    public Text move3;
    public Text move4;


    [Header("pokname")]
    public Text Ourpokname;
    public Text Enemypokname;

    // pp toevoegen
    [Header("misc")]
    public Text Eventtekst;
    public party pokemonparty;


    // public rekemachine;
    //stats
    //types
    // speed ourpok == speed enemypok; then random int


    public battlesceneHider longmoves;
    public battlesceneHider fbpr;
    private Pokemon ourpok;
    private Pokemon enemypok;
    

    void Start()
    {
        //toevoegen van de pokemonparty
        pokemonparty = (GameObject.FindWithTag("party").GetComponent<party>() as party);

        // als of fight, dan fight - hide en long moves - show.

        //fightbutton - als je klikt gaat figntbuttonfunction aan.
        FightButton.onClick.AddListener(Fightbuttonfunction);
        //longmoves (panel) staat uit. 
        longmoves.changeVisibility(false);
        //backbutton - als je klikt gaat backbutotnfunction aan.
        backbutton.onClick.AddListener(Backbuttonfunction);

        ourpok = pokemonparty.pokemons[0];
        enemypok = pokemonparty.trainer.pokemons[0];

        //aanroepen van updateUI
        updateUI();
        



    }

    void Fightbuttonfunction()
    {
        longmoves.changeVisibility(true);
        fbpr.changeVisibility(false);

    }

    void Backbuttonfunction()
    {
        longmoves.changeVisibility(false);
        fbpr.changeVisibility(true);



    }

    void updateUI()
    {
        // aanroepen van player spirte
        Ourpoksprite.sprite = ourpok.sprite;

         //aamroepen van enemysprite
        Enemypoksprite.sprite = enemypok.sprite;

        //pokemonnamen toevoegen
        Ourpokname.text = ourpok.name;
        Enemypokname.text = enemypok.name; 

        //veranderen 'move #' naar *movenaam*
        move1.text = ourpok.moves[0].name;
        move2.text = ourpok.moves[1].name;
        move3.text = ourpok.moves[2].name;
        move4.text = ourpok.moves[3].name;

        Eventtekst.text = "What will " + ourpok.name + " do?";
        



    }

    IEnumerator Startbattleround(move attackOur, move attackEnemy)
    {
        longmoves.changeVisibility(false);
        fbpr.changeVisibility(false);

        yield return new WaitForSeconds(1);
        //move 1
        yield return new WaitForSeconds(1);
        //move 2
        yield return new WaitForSeconds(1);
        //battleselection


        //eventtekst
        //hit. wacht 1 tel, 2e hit


    }
}




// eventtekst - pok used move 1
// berekening - hp / displaybar
//eventtekst, effectiveness
// eventtekst - pok used move 2
// berekening - hp / displaybar
//eventtekst, effectiveness
//reset

