using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addMoves : MonoBehaviour
{
    public GameObject draggableMove;
    public GameObject slot;
    public GameObject Party;
    private List<Pokemon> partyPokemons;
    private int key;
    private GameObject buildingSlot;
    /*
    private void Start()
    {
        Party = GameObject.FindGameObjectWithTag("party");
        partyPokemons = (Party.GetComponent("party") as party).pokemons;
        makeMoves(partyPokemons[0]);
    }
    */
    public void addKey(int newKey)
    {
        key = newKey;
    }
    public void makeMoves(Pokemon pokemon)
    {
        foreach (move Move in pokemon.moves)
        {
            buildingSlot =  Instantiate(slot, transform);
            buildingSlot.SendMessage("addKey", key);
            buildingSlot.SendMessage("occupyWith", Move);
        }
    }
}
