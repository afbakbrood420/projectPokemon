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

    // Start is called before the first frame update
    public void setPokemon(Pokemon newPokemon, int newHp, int newIndex)
    {
        pokemon = newPokemon;
        indexInParty = newIndex;
        hp = newHp;
        txt.text = pokemon.name;
        img.sprite = pokemon.sprite;
        button.onClick.AddListener(chooseTarget);
        updateHp(newHp);

    }
    public void visibility(bool visible)
    {
        img.enabled = visible;
        txt.enabled = visible;
        hpBar.enabled = visible;
        hpBar.visibility(visible);
        buttonImg.enabled = visible;
        button.enabled = visible;
        blocker.enabled = visible;
        updateHp(FindObjectOfType<party>().GetComponent<party>().HPs[indexInParty]);
    }
    void chooseTarget()
    {
        try
        {
            GameObject.FindObjectOfType<ItemManager>().GetComponent<ItemManager>().chooseTarget(indexInParty);
        }
        catch 
        {
            (GameObject.FindObjectOfType<Battle_Script>().GetComponent<Battle_Script>() as Battle_Script).switchPokemon(indexInParty);
        } 

    }
    public void updateHp(int newHp)
    {
        hp = newHp;
        hpBar.value = (float)hp / (float)pokemon.HP;
        if (newHp <= 0)
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


