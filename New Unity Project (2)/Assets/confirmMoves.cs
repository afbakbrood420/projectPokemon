using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class confirmMoves : MonoBehaviour
{

    public GameObject moveListPrefab;
    public GameObject moveListParent;
    public Button confirmButton;
    

    private List<GameObject> moveLists = new List<GameObject> { };
    private GameObject prefabToAdd;
    private List<List<move>> movesOfPokemons = new List<List<move>> { };
    

    //for debugging
    public List<Pokemon> testParty = new List<Pokemon> { };
    public bool useTestParty;
    public bool enableDebug;
    private string debugPackage;
    private int count = 0;

    void Start()
    {
        if (useTestParty)
        {
            count = 0;
            foreach (Pokemon pokemon in testParty)
            {
                prefabToAdd = Instantiate(moveListPrefab, moveListParent.transform);
                (prefabToAdd.GetComponent("moveCollector") as moveCollector).setPokemon(pokemon, count);
                moveLists.Add(prefabToAdd);
                count += 1;
            }
        }
        else
        {
            count = 0;
            foreach (Pokemon pokemon in (GameObject.FindGameObjectWithTag("party").GetComponent("party") as party).pokemons)
            {
                prefabToAdd = Instantiate(moveListPrefab, moveListParent.transform);
                (prefabToAdd.GetComponent("moveCollector") as moveCollector).setPokemon(pokemon, count);
                moveLists.Add(prefabToAdd);
                count += 1;
            }
        }
        confirmButton.onClick.AddListener(collectMoves);
    }
    void collectMoves()
    {
        movesOfPokemons.Clear();
        foreach (GameObject moveList in moveLists)
        {
            movesOfPokemons.Add((moveList.GetComponent("moveCollector") as moveCollector).getMoves());
        }
        if (enableDebug)
        {
            count = 0;
            foreach (List<move> moveSet in movesOfPokemons)
            {
                debugPackage = "Pokemon: "+count.ToString()+" moveSet: ";
                foreach (move Move in moveSet)
                {
                    debugPackage += Move.name+ ", ";
                }
                Debug.Log(debugPackage);
                count += 1;
            }
        }
    }
}
