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
 
    public battlesceneHider longmoves;
    public battlesceneHider fbpr;
    public move incapacitatedMove;

    [Header("swapPokemon")]
    public showHide pokSlcShowHide;
    public Button pokSlcBack;

    [Header("not for editor")]
    public Pokemon ourpok;
    public int ourpokIndex;
    public Pokemon enemypok;
    public int enemyPokIndex;
    public List<int> enemyHps = new List<int> { };

    //results for damage calculation functions
    private float effectiveness;
    private float stabResult;
    private float atDefResult;
    private float damage;

    //variables for storing the attacks in order
    private bool playerIsFirst;
    private move enemyMoveWhenItem;
    private bool playerHasFreeAction = false;
    private bool playerWon = false;


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

        //zorg dat de goede functies worden uitgevoerd op een buttonpress
        backbutton.onClick.AddListener(Backbuttonfunction);
        BagButton.onClick.AddListener(bag);
        PokemonButton.onClick.AddListener(pokemonButtonFunction);
        pokSlcBack.onClick.AddListener(pokSlcBackBtnFunction);
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
            pokemonparty.inBattle = true;
            ourpok = pokemonparty.pokemons[0];
            ourpokIndex = 0;
            enemypok = pokemonparty.trainer.pokemons[0];
            enemyPokIndex = 0;

            foreach (Pokemon pokemon in pokemonparty.trainer.pokemons)
            {
                enemyHps.Add(pokemon.HP);
            }
        }

        Eventtekst.text = "What will " + ourpok.name + " do?";
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
    void pokemonButtonFunction()
    {
        pokSlcShowHide.show();
    }
    void pokSlcBackBtnFunction()
    {
        pokSlcShowHide.hide();
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

        // ourpok hp
        OurPokMaxHp.text = ourpok.HP.ToString();
        ourPokHp.text = pokemonparty.HPs[ourpokIndex].ToString();
        dbOurpok.value = (float)pokemonparty.HPs[ourpokIndex] / (float)ourpok.HP;
        try //this needs a try statement because it will throw an error once the enemypokindex is higher then the list. which
        {   //happens when the player wins.
            dbEnemypok.value = (float)enemyHps[enemyPokIndex] / (float)enemypok.HP;
        }
        catch (System.Exception)
        {
            
        }
        

    }

    //coroutines duren langer dan 1 frame dit is een coroutine
    IEnumerator Startbattleround(move attackOur, move attackEnemy)
    {
        longmoves.changeVisibility(false);
        fbpr.changeVisibility(false);
        Debug.Log("enemyPok used: " + attackEnemy.name);
        Debug.Log("ourPok used: " + attackOur.name);

        if (ourpok.Speed >= enemypok.Speed)
        {
            playerIsFirst = true;
        }
        else
        {
            playerIsFirst = false;
        }

        yield return new WaitForSeconds(2); //hier wachten wij 1 seconden voordat het script word hervat
        //move 1
        displayAttack(attackEnemy, attackOur, true);

        yield return new WaitForSeconds(2);
        useMove(attackOur, attackEnemy, true);
        updateUI();

        yield return new WaitForSeconds(2);
        displayAttack(attackEnemy, attackOur, false);

        yield return new WaitForSeconds(2);
        //battleselection
        useMove(attackOur, attackEnemy, false);
        updateUI();
        yield return new WaitForSeconds(2);


        //eventtekst
        //hit. wacht 1 tel, 2e move
        longmoves.changeVisibility(false);
        fbpr.changeVisibility(true);
        Eventtekst.text = "What will " + ourpok.name + " do?";
        updateUI();
        checkForFaint();
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
        if (playerHasFreeAction)
        {
            StartCoroutine(Startbattleround(pokemonparty.moveSets[ourpokIndex][moveIndex], incapacitatedMove));
        }
        else
        {
            StartCoroutine(Startbattleround(pokemonparty.moveSets[ourpokIndex][moveIndex], enemypok.moves[(int)Mathf.Round(Random.Range(0f, 3.4f))]));
        }
        playerHasFreeAction = false;
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
        DisplayEffectiveness(effectiveness);
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
            Eventtekst.text = "its effective";
        }
    }

    //stab is een term voor pokemonspelers het staat voor same type attack bonus en geeft een extra boost aan de kracht van de aanval als
    //er bepaalde eisen worden voldaan.
    float stab(Pokemon defender, Pokemon attacker, move Move)
    {
        stabResult = 1f;

        if (attacker.Attack >= attacker.SpAttack || Move.isSpecial == false || attacker.types.Contains(Move.type))
        {
            stabResult = 1.5f;
        }
        else if (attacker.SpAttack >= attacker.Attack || Move.isSpecial == true || attacker.types.Contains(Move.type))
        {
            stabResult = 1.5f;
        }
        return stabResult;
    }

    //atDef is een term voor pokemon fans om uit een bepaalde game mechanic uit te drukken. Er komt namelijk een bonus als de situatie
    //aan bepaalde eisen worden voldaan. 
    float atDef(Pokemon defender, Pokemon attacker, move Move)
    {
        if (Move.isSpecial == false)
        {
            atDefResult = (float)attacker.Attack / (float)defender.Defense;
        }
        else
        {
            atDefResult = (float)attacker.SpAttack / (float)defender.SpDefense;
        }
        return atDefResult;
    }


    float CalcDamage(Pokemon defender, Pokemon attacker, move Move)
    {
        damage = atDef(defender, attacker, Move) * stab(defender, attacker, Move) * checkEffectiveness(Move, defender) * Move.power * 0.25f;
        return damage;
    }


    void useMove(move attackOur, move attackEnemy, bool isFirstMove)
    { //all the if statements are for checking which pokemon goes first
        if (isFirstMove)
        {
            if (playerIsFirst)
            {
                //use player move
                //hp = hp - damage and damage is rounded to an int, because pokemon can only have an rounded number in hp.
                enemyHps[enemyPokIndex] = enemyHps[enemyPokIndex] - (int)Mathf.Round(CalcDamage(enemypok, ourpok, attackOur));
            }
            else
            {
                //use enemy move. just the same as the one a few lines above. But reversed, so the player is defending and the enemy attacking.
                pokemonparty.HPs[ourpokIndex] = pokemonparty.HPs[ourpokIndex] - (int)Mathf.Round(CalcDamage(ourpok, enemypok, attackEnemy));
            }
        }
        else
        {
            if (playerIsFirst == false)
            {
                enemyHps[enemyPokIndex] = enemyHps[enemyPokIndex] - (int)Mathf.Round(CalcDamage(enemypok, ourpok, attackOur));
            }
            else
            {
                pokemonparty.HPs[ourpokIndex] = pokemonparty.HPs[ourpokIndex] - (int)Mathf.Round(CalcDamage(ourpok, enemypok, attackEnemy));
            }
        }
        checkForFaint();
    }


    void displayAttack(move attackEnemy, move attackOur, bool isFirstMove)
    {
        if (playerIsFirst == isFirstMove) { Eventtekst.text = ourpok.name + " used " + attackOur.name; }
        else { Eventtekst.text = enemypok.name + " used " + attackEnemy.name; }
    }


    void interruptBattleRound()
    {
        longmoves.changeVisibility(false);
        fbpr.changeVisibility(true);
        Eventtekst.text = "What will " + ourpok.name + " do?";
        updateUI();
        StopAllCoroutines();
    }


    public void switchPokemon(int newIndex)
    {
        pokSlcBack.interactable = true;
        ourpokIndex = newIndex;
        ourpok = pokemonparty.pokemons[newIndex];
        pokSlcShowHide.hide();
        updateUI();
        longmoves.changeVisibility(false);
        fbpr.changeVisibility(false);

        Eventtekst.text = ourpok.name + " I choose you!";
        StartCoroutine(enemyFreeAction());
    }


    public void spendItem(Item item)
    {
        longmoves.changeVisibility(false);
        fbpr.changeVisibility(false);

        Eventtekst.text = "you used a " + item.name;
        StartCoroutine(enemyFreeAction());
    }


    public IEnumerator enemyFreeAction()
    {
        yield return new WaitForEndOfFrame();
        if (playerHasFreeAction)
        {
            enemyMoveWhenItem = incapacitatedMove;
            playerHasFreeAction = false;
        }
        else
        {
            enemyMoveWhenItem = enemypok.moves[(int)Mathf.Round(Random.Range(0f, 3.4f))];
        }
        playerHasFreeAction = false;
        Eventtekst.text = enemypok.name + " used " + enemyMoveWhenItem.name;
        yield return new WaitForSeconds(2);
        DisplayEffectiveness(checkEffectiveness(enemyMoveWhenItem, ourpok));
        pokemonparty.HPs[ourpokIndex] = pokemonparty.HPs[ourpokIndex] - (int)Mathf.Round(CalcDamage(ourpok, enemypok, enemyMoveWhenItem));
        checkForFaint();
        yield return new WaitForSeconds(2);
        interruptBattleRound();
        checkForFaint();
    }


    void checkForFaint()
    {
        if (enemyHps[enemyPokIndex] <= 0)
        {
            Debug.Log("enemy pokemon fainted");
            interruptBattleRound();
            enemyHps[enemyPokIndex] = 0;

            playerHasFreeAction = true;
            enemyPokIndex += 1;
            if (enemyPokIndex > pokemonparty.trainer.pokemons.Count -1)
            {
                pokemonparty.endBattle();
                return;
            }

            enemypok = pokemonparty.trainer.pokemons[enemyPokIndex];
            updateUI();
            Debug.Log(playerHasFreeAction);
        }
        else if (pokemonparty.HPs[ourpokIndex] <= 0)
        {
            Debug.Log("our pokemon fainted");
            interruptBattleRound();
            pokemonparty.HPs[ourpokIndex] = 0;
            pokemonparty.fainted[ourpokIndex] = false;
            pokemonButtonFunction();
            pokSlcBack.interactable = false;
            fbpr.changeVisibility(false);
        }
        checkforWinnings();
    }
    void checkforWinnings()
    {
        if (pokemonparty.fainted.Contains(true) == false)
        {
            foreach (bool i in pokemonparty.fainted)
            {
                Debug.Log(i);
            }
            pokemonparty.lose();
        }
        else
        {
            playerWon = true;
            foreach (int hp in enemyHps)
            {
                if (hp > 0)
                {
                    playerWon = false;
                }
            }
            if (playerWon)
            {
                pokemonparty.endBattle();
            }
        }
    }
}




// eventtekst - pok used move 1
// berekening - hp / displaybar
//eventtekst, effectiveness
// eventtekst - pok used move 2
// berekening - hp / displaybar
//eventtekst, effectiveness
//reset


