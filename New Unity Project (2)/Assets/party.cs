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
    // Start is called before the first frame update
    void Start()
    {
        if (isTestParty == false)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
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
    public void setMoves(List<List<move>> newMoves)
    {
        moveSets = newMoves;
        SceneManager.LoadScene("Scenes/map");
    }

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
    public void exitInventory()
    {
        SceneManager.LoadScene(2);
    }
    public void accesInventory()
    {
        SceneManager.LoadScene(3);
    }
    
}
