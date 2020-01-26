using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PokemonSelector : MonoBehaviour
{
    //all the variables and objects that I can change in this script.
    public Dropdown selector;
    public Image display;
    public Pokemon pokemon; //make sure that this is public so we can acces it in the confirm button script.
    public GameObject searchfield;
    private List<string> pokemonNames = new List<string> { };
    private List<Pokemon> pkmDatabase;

    //somehow subscribe to the list with all pokemon inside

    void onSelectChange()
    {
        //get the new pokemon and store it in pokemon
        //this script runs when you pick a different pokemon on the dropdown menu, and makes sure that the sprite updates.
        pokemon = pkmDatabase[selector.value]; //the selector.value returns an index of the list of options. So because I gave 
                                            //him the pokemons list, I can return the pokemon
        display.sprite = pokemon.sprite; //update the sprite
    }
    public void setPrePokemon(List<Pokemon> prePokemons)
    {
        pkmDatabase = prePokemons;
        
        foreach (Pokemon pokemon in prePokemons)
        {
            pokemonNames.Add(pokemon.name); //get a list of all the pokemon names for the dropdown menu
        }
        selector.AddOptions(pokemonNames); //add the list to the dropdown menu
        onSelectChange();
    }
}
