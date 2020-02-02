using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class party : MonoBehaviour
{
    public List<Pokemon> pokemons = new List<Pokemon> { };
    public List<int> HPs = new List<int> { };
    public List<List<move>> moveSets = new List<List<move>> { };
    public List<Item> items = new List<Item> { };
    public List<int> itemAmounts = new List<int> { };
    public bool isTestParty;
    /*
     * this script is designed to keep track of variables across scenes. the data in this object can be accessed by all scripts in a scene.
     * in start we make sure that this object is immortal, which means that it is not scene bound.
     * this script also acts as a scene manager, this is in charge of loading new scenes.
     */


    void Start()
    {
        if (isTestParty == false)
        {
            DontDestroyOnLoad(gameObject); //makes sure that this object is immortal
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
        if (HPs[index]>pokemons[index].HP)
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
        SceneManager.LoadScene("Scenes/map");
    }

    //for accesing the inventory
    public void accesInventory()
    {
        Debug.Log("transitioning...");
        SceneManager.LoadScene("Scenes/inventory");
    }
    
}
