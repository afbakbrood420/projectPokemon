using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class confirmButton : MonoBehaviour
{
    public Button btn;
    public List<GameObject> pokemonSelectors = new List<GameObject> {};
    private List<Pokemon> newParty = new List<Pokemon> { };
    public GameObject party;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(taskOnClick);
    }
    void taskOnClick()
    {
        newParty.Clear();
        foreach (GameObject pokemonSelector in pokemonSelectors)
        {
            newParty.Add((pokemonSelector.GetComponent("PokemonSelector") as PokemonSelector).pokemon);
        }
        party.SendMessage("IchooseThese", newParty);
    }
}
