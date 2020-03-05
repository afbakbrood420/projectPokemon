using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetFinder : MonoBehaviour
{
    public Pokemon pokemon;
    public displayBar hpBar;
    public Image img;
    public Image buttonImg;
    public Image blocker;
    public Button button;
    public Text txt;
    public int hp;
    public int indexInParty;
    public Image backgroundImage;
    public Color faintedColor;
    public Color normalColor;
    private party Party;
    private bool usedForPokemonSwap;

    /*
     * this script is responsible for all UI in the targetfinder object. It also handles the button.
     * this object is used in 2 scenes, thats why its a little more complex
     */
    
    // Start is called before the first frame update
    public void setPokemon(Pokemon newPokemon, int newHp, int newIndex) //receive the pokemon and its hp from the builder
    {
        pokemon = newPokemon;
        indexInParty = newIndex;
        hp = newHp;
        txt.text = pokemon.name; //sets up UI
        img.sprite = pokemon.sprite;
        button.onClick.AddListener(chooseTarget);
        updateHp(newHp);
        usedForPokemonSwap = FindObjectOfType<Battle_Script>() != null; //checks if we are in battlescene, and if so its true
    }
    public void visibility(bool visible)
    {
        img.enabled = visible; //make everything visible or invisible
        txt.enabled = visible;
        hpBar.enabled = visible;
        hpBar.visibility(visible);
        buttonImg.enabled = visible;
        button.enabled = visible;
        blocker.enabled = visible;
        updateHp(FindObjectOfType<party>().GetComponent<party>().HPs[indexInParty]); //updates hp this might have changed when in battle
    }
    void chooseTarget()
    {
        if(usedForPokemonSwap)
        {
            FindObjectOfType<Battle_Script>().GetComponent<Battle_Script>().switchPokemon(indexInParty); //swaps pokemon to the new one
        }
        else //if used in the inventory
        {
            FindObjectOfType<ItemManager>().GetComponent<ItemManager>().chooseTarget(indexInParty); //uses the item on this pokemon
        } 
    }
    public void updateHp(int newHp)
    {
        hp = newHp;
        hpBar.value = (float)hp / (float)pokemon.HP; 
        if (newHp <= 0 && usedForPokemonSwap) //makes you inable to switch to that pokemon if its dead
        {
            button.enabled = false;
            backgroundImage.color = faintedColor;
        }
        else 
        {
            backgroundImage.color = normalColor;
        }
    }
}


