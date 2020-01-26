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
        foreach (GameObject item in listElements)
        {
            Destroy(item);
        }
        listElements.Clear();
        party = GameObject.FindGameObjectWithTag("party");
        partyPokemons = (party.GetComponent("party") as party).pokemons;
        count = 0;
        foreach (Pokemon partyPokemon in partyPokemons)
        {
            elementtoBuild = Instantiate(listElementPrefab, transform);
            (elementtoBuild.GetComponent("listElement") as listElement).setText(partyPokemon.name, count);
            listElements.Add(elementtoBuild);
            count += 1;
        }
        
    }
    public void changeSelectedPokemon(int newIndex)
    {
        currentIndex =  newIndex;
        //Debug.Log("choosing: " + currentIndex.ToString());
        foreach (GameObject listElement in listElements)
        {
            listElement.SendMessage("deselect");
        }
        //Debug.Log("listElements = ");
        listElements[currentIndex].SendMessage("select");
        Debug.Log(currentIndex.ToString());
        moveListSR.verticalNormalizedPosition = (float)currentIndex / 5f;
        Debug.Log(moveListSR.verticalNormalizedPosition);
    }
    /*
    void taskOnClick()
    {
        moveListSR.verticalNormalizedPosition = 1 / 6;
    }
    */
}
