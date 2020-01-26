using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveCollector : MonoBehaviour
{
    public List<GameObject> chosenSlotList = new List<GameObject> { };
    public List<move> moves = new List<move> { };
    public GameObject moveAdder;
    public Image pokemonIMG;
    public int key;
    public string errorMsgIfNoMoveAssigned = "please choose all the moves for your pokemons, all slots must be filled";
    public GameObject statDisplayerPrefab;
    public GameObject statDisplayerParent;
    public List<string> stats = new List<string> { };
    //public GameObject moveListPrefab;

    private move moveToAdd;
    private List<GameObject> statDisplays = new List<GameObject> { };

    public List<move> getMoves()
    {
        moves.Clear();
        foreach (GameObject slot in chosenSlotList)
        {
            try
            { // getting move, in a try statement because it gives an error if there is no move in the slot.
                moveToAdd = ((slot.GetComponent("snappable") as snappable).objectInSlot.GetComponent("selectMove") as selectMove).Move;
            }
            catch
            { //if there is no move in the slot, notify the player that not all moves are assigned.
                GameObject.FindGameObjectWithTag("popUpWindow").SendMessage("notification", errorMsgIfNoMoveAssigned);
            }
            moves.Add(moveToAdd);
        }
        return moves;
    }
    public void setPokemon(Pokemon pokemon, int newKey)
    {
        key = newKey;
        moveAdder.SendMessage("addKey", key);
        moveAdder.SendMessage("makeMoves", pokemon);
        pokemonIMG.sprite = pokemon.sprite;

        foreach (GameObject chosenSlot in chosenSlotList)
        {
            chosenSlot.SendMessage("addKey", key);
        }

        //update the stat displayers
        statDisplays.Clear();
        foreach (string stat in stats)
        {
            statDisplays.Add(Instantiate(statDisplayerPrefab, statDisplayerParent.transform));
            statDisplays[statDisplays.Count-1].SendMessage("setStat", stat);
            statDisplays[statDisplays.Count - 1].SendMessage("setValue", (int)pokemon.GetType().GetField(stat).GetValue(pokemon));
            //https://forum.unity.com/threads/access-variable-by-string-name.42487/ the last variable in the send message is from this forum.
        }
        
    }
}
