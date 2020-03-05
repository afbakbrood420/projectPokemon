using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allPokemonDb : MonoBehaviour
{
    public List<Pokemon> pokemons = new List<Pokemon> { };
    public List<Pokemon> pokemontwo = new List<Pokemon> { };
        
    /*
     this script makes sure that the pokemonselectors have the right lists of pokemon.
     the pokemons list has been assigned in the editor
     */

    void Start()
    {
        foreach (Transform selector in gameObject.GetComponentInChildren<Transform>()) //just a forloop through the childobjects of this object
        {
            selector.gameObject.SendMessage("setPrePokemon", pokemontwo); //sends the lists of all possible pokemon to that object
        }
    }
    
}
