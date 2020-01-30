using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetFinderBuilder : MonoBehaviour
{
    // Start is called before the first frame update
    private party Party;
    private List<targetFinder> targetFinders = new List<targetFinder> { };
    public GameObject targetFinderPrefab;
    private int count = 0;
    void Start()
    {
        Party = (GameObject.FindGameObjectWithTag("party").GetComponent("party") as party);
        foreach (Pokemon pokemon in Party.pokemons)
        {
            
            targetFinders.Add(Instantiate(targetFinderPrefab).GetComponent("targetFinder") as targetFinder);
            targetFinders[count].setPokemon(pokemon,Party.HPs[count]);
            count = count + 1;
        }
    }
}
