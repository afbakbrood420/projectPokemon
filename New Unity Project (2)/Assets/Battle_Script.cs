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
    public Button move0b;
    public Button move1b;
    public Button move2b;
    public Button move3b;
    public Button backbutton;
    public Text move1;
    public Text move2;
    public Text move3;
    public Text move4;


    [Header("pokUI")]
    public Text Ourpokname;
    public Text Enemypokname;
    public Text OurPokMaxHp;
    public Text ourPokHp;



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

    [Header("not for editor")]
    public Pokemon ourpok;
    public int ourpokIndex;
    public Pokemon enemypok;
    public int enemyPokIndex;
    public List<int> enemyHps = new List<int> { };

    private float effectiveness;
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
        BagButton.onClick.AddListener(bag);
        initiateMoveButtons();




        if (pokemonparty.inBattle)
        {
            //resuming the battle
            enemyHps = pokemonparty.EnemyHps;
            enemyPokIndex = pokemonparty.enemyPokemonIndex;
            enemypok = pokemonparty.trainer.pokemons[enemyPokIndex];


            ourpokIndex = pokemonparty.currentPokemonIndex;
            ourpok = pokemonparty.pokemons[ourpokIndex];
        }
        else
        {
            //making a new battle
            ourpok = pokemonparty.pokemons[0];
            ourpokIndex = 0;
            enemypok = pokemonparty.trainer.pokemons[0];
            enemyPokIndex = 0;

            foreach (Pokemon pokemon in pokemonparty.trainer.pokemons)
            {
                enemyHps.Add(pokemon.HP);
            }
        }

        //de pokemon = de bovenste pokemon

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
        //de goede sprite in de Image component zetten
        Ourpoksprite.sprite = ourpok.sprite;

        //de goede sprite in de Image component zetten
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

        // ourpok hp
        OurPokMaxHp.text = ourpok.HP.ToString();
        ourPokHp.text = pokemonparty.HPs[ourpokIndex].ToString();
        dbOurpok.value = (float)pokemonparty.HPs[ourpokIndex] / (float)ourpok.HP;
        dbEnemypok.value = (float)enemyHps[enemyPokIndex] / (float)enemypok.HP;

    }

    //coroutines duren langer dan 1 frame dit is een coroutine
    IEnumerator Startbattleround(move attackOur, move attackEnemy)
    {
        longmoves.changeVisibility(false);
        fbpr.changeVisibility(false);
        Debug.Log("enemyPok used: " + attackEnemy.name);
        Debug.Log("ourPok used: " + attackOur.name);

        yield return new WaitForSeconds(2); //hier wachten wij 1 seconden voordat het script word hervat
        //move 1
        Eventtekst.text = ourpok.name + " used " + attackOur.name;
        yield return new WaitForSeconds(2);
        DisplayEffectiveness(checkEffectiveness(attackOur,enemypok));
        yield return new WaitForSeconds(2);
        //battleselection


        //eventtekst
        //hit. wacht 1 tel, 2e move
        longmoves.changeVisibility(true);
        fbpr.changeVisibility(true);
    }

    void bag()
    {
        pokemonparty.accesInventory();
    }
    void endBattle()
    {
        pokemonparty.inBattle = false;
        pokemonparty.trainersDefeated.Add(pokemonparty.trainer);
        pokemonparty.endBattle();
    }
    void initiateMoveButtons() 
    {
        move0b.onClick.AddListener(() => chooseMove(0));
        move1b.onClick.AddListener(() => chooseMove(1));
        move2b.onClick.AddListener(() => chooseMove(2));
        move3b.onClick.AddListener(() => chooseMove(3));
    }

    void chooseMove(int moveIndex)
    {
        StartCoroutine(Startbattleround(pokemonparty.moveSets[ourpokIndex][moveIndex] , enemypok.moves[0]));
    }
    float checkEffectiveness(move usedMove, Pokemon Defender)
    {
        effectiveness = 1f;
        foreach (Type type in Defender.types)
        {
            foreach (Type resistance in type.resistances)
            {
                if (resistance == usedMove.type)
                {
                    //move is not very effective
                    effectiveness = effectiveness * 0.5f;
                }
            }
            foreach (Type weakness in type.vunerabilities)
            {
                if (weakness == usedMove.type)
                {
                    //move is super effective
                    effectiveness = effectiveness * 2f;
                }
            }
            foreach (Type immunity in type.immunities)
            {
                if (immunity == usedMove.type)
                {
                    //move has no effect
                    effectiveness = 0f;
                }
            }
        }
        return effectiveness;
    }
    void DisplayEffectiveness(float effectiveness)
    {
        if (effectiveness > 1f)
        {
            Eventtekst.text = "its super effective!";
        }
        else if (effectiveness < 1f)
        {
            Eventtekst.text = "its not very effective...";
        }
        else if (effectiveness == 1f)
        {
            Debug.Log("effectiveness = 1");
        }
        Debug.Log("effectiveness = "+effectiveness.ToString());
    }
}




// eventtekst - pok used move 1
// berekening - hp / displaybar
//eventtekst, effectiveness
// eventtekst - pok used move 2
// berekening - hp / displaybar
//eventtekst, effectiveness
//reset

