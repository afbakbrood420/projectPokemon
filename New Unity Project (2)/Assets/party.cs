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
        }

        SceneManager.LoadScene(1);
    }
    void setMoves(List<List<move>> newMoves)
    {
        moveSets = newMoves;
    }
}
