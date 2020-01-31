using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetFinder : MonoBehaviour
{
    public Pokemon pokemon;
    public displayBar hpBar;
    public Image img;
    public Text txt;
    public int hp;
    // Start is called before the first frame update
    public void setPokemon(Pokemon newPokemon, int newHp)
    {
        pokemon = newPokemon;
        hp = newHp;
        txt.text = pokemon.name;
        img.sprite = pokemon.sprite;
        hpBar.value = (float)hp / (float)pokemon.HP;
    }
    public void visibility(bool visible)
    {
        Debug.Log("bravo 6 going dark");
        img.enabled = visible;
        txt.enabled = visible;
        hpBar.enabled = visible;

    }
}
