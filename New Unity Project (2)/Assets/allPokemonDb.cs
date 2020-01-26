using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allPokemonDb : MonoBehaviour
{
    public List<Pokemon> pokemons = new List<Pokemon> { };
    void Start()
    {
        foreach (Transform selector in gameObject.GetComponentInChildren<Transform>())
        {
            selector.gameObject.SendMessage("setPrePokemon", pokemons);
        }
    }
    
}
