using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class listManager : MonoBehaviour
{
    public GameObject listElementPrefab;
    public GameObject party;
    public List<Pokemon>partyPokemons = new List<Pokemon> {};
    public int currentIndex;
    public ScrollRect moveListSR;

    private List<GameObject> listElements = new List<GameObject> { };
    private GameObject elementtoBuild;
    private int count;


    private void Start()
    {
        //makes sure the list is clear and ready to go
        foreach (GameObject item in listElements)
        {
            Destroy(item);
        }
        listElements.Clear();

        //get the chosen pokemons out of the party
        party = GameObject.FindGameObjectWithTag("party");
        partyPokemons = (party.GetComponent("party") as party).pokemons;
        count = 0;
        
        //makes a prefab for each of the chosen pokemon in the party and put it in a list
        foreach (Pokemon partyPokemon in partyPokemons)
        {
            elementtoBuild = Instantiate(listElementPrefab, transform);
            (elementtoBuild.GetComponent("listElement") as listElement).setText(partyPokemon.name, count); //makes sure that it knows what it represents
            listElements.Add(elementtoBuild);
            count += 1;
        }
        
    }
    //this is connected to the buttons of the listElements
    public void changeSelectedPokemon(int newIndex)
    {
        currentIndex =  newIndex;
        foreach (GameObject listElement in listElements) //deselect all the other elements
        {
            listElement.SendMessage("deselect");
        }
        
        //select the right one
        listElements[currentIndex].SendMessage("select");
        Debug.Log(currentIndex.ToString());
        moveListSR.verticalNormalizedPosition = 1f - ((float)currentIndex / 6f); //move the list to the pokemon
        Debug.Log(moveListSR.verticalNormalizedPosition);
    }
}
