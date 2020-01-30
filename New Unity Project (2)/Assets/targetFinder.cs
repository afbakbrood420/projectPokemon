using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetFinder : MonoBehaviour
{
    public Pokemon pokemon;
    public displayBar hpBar;
    public int hp;
    // Start is called before the first frame update
    public void setPokemon(Pokemon newPokemon, int newHp)
    {
        pokemon = newPokemon;
        hp = newHp;
        hpBar.value = (float)hp / (float)pokemon.HP;
    }
}
