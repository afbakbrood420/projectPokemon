using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class party : MonoBehaviour
{
    public Trainer trainer;
    public List<Pokemon> pokemons = new List<Pokemon> { };
    public List<int> HPs = new List<int> { };
    public List<List<move>> moveSets = new List<List<move>> { };
    public List<Item> items = new List<Item> { };
    public List<int> itemAmounts = new List<int> { };
    public bool isTestParty;
    public bool inBattle = false;
    public bool automateMoveSelection = false;

    [Header("not to be assigned in the editor")]
    public int firsPokemonIndex;
    public int currentPokemonIndex;
    public int enemyPokemonIndex;
    public List<int> EnemyHps;
    public List<Trainer> trainersDefeated;
    /*
     * this script is designed to keep track of variables across scenes. the data in this object can be accessed by all scripts in a scene.
     * in start we make sure that this object is immortal, which means that it is not scene bound.
     * this script also acts as a scene manager, this is in charge of loading new scenes.
     */

    private Battle_Script battle_Script;
    private List<move> moveSetToAdd = new List<move> { };

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("party").Length > 1)
        {
            Destroy(gameObject);
        }
        if (isTestParty == false)
        {
            DontDestroyOnLoad(gameObject); //makes sure that this object is immortal
        }
        if (automateMoveSelection)
        {
            //make test movesets by just taking the first 4
            foreach (Pokemon pokemon in pokemons)
            {
                moveSetToAdd = new List<move> { };
                for (int i = 0; i < 4; i++)
                {
                    moveSetToAdd.Add(pokemon.moves[i]);
                }
                moveSets.Add(moveSetToAdd);
            }
        }
    }
    //this is called by an object in the pokemonselector screen once all the pokemons are chosen
    void IchooseThese(List<Pokemon> newParty)
    {
        pokemons.Clear();
        foreach (Pokemon newPokemon in newParty)
        {
            pokemons.Add(newPokemon);
            HPs.Add(newPokemon.HP);
        }

        SceneManager.LoadScene(1);
    }

    //this is called by an object in the moveselector screen once all the moves are chosen.
    public void setMoves(List<List<move>> newMoves)
    {
        moveSets = newMoves;
        SceneManager.LoadScene("Scenes/map");
    }

    //this is called once an item is used in the inventory scene
    public void applyItem(Item item, int index)
    {
        HPs[index] = HPs[index] + item.healing;
        if (HPs[index] > pokemons[index].HP)
        {
            HPs[index] = pokemons[index].HP;
        }
        itemAmounts[items.IndexOf(item)] -= 1;
        if (itemAmounts[items.IndexOf(item)] == 0)
        {
            items.Remove(item);
        }
    }

    //for exiting the inventory
    public void exitInventory()
    {
        if (inBattle)
        {
            SceneManager.LoadScene("Scenes/battle");
        }
        else
        {
            SceneManager.LoadScene("Scenes/map");
        }
    }

    //for accesing the inventory
    public void accesInventory()
    {
        if (inBattle)
        {
            battle_Script = FindObjectOfType<Battle_Script>().GetComponent<Battle_Script>();
            //get the index of the pokemon now in battle
            currentPokemonIndex = pokemons.IndexOf(battle_Script.ourpok);

            //get the index of the enemies pokemon now in battle
            enemyPokemonIndex = battle_Script.enemyPokIndex;

            //store the hps of the enemy
            EnemyHps = battle_Script.enemyHps;
        }
        else
        {

        }
        SceneManager.LoadScene("Scenes/inventory");
    }
    public void startFight(Trainer newTrainer)
    {
        trainer = newTrainer;
        SceneManager.LoadScene("Scenes/battle");
    }
    public void endBattle()
    {
        SceneManager.LoadScene("Scenes/map");
    }


}


