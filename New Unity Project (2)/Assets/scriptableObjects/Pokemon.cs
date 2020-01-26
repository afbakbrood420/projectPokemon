using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Pokemon", fileName ="bulbasaur")]
public class Pokemon : ScriptableObject
{
    public int HP;
    public int Attack;
    public int Defense;
    public int SpAttack;
    public int SpDefense;
    public int Speed;

    public List<move> moves = new List<move> { };

    public string pokedexEntry;

    public Sprite sprite;
    public Sprite shinySprite;

    public List<Type> types = new List<Type> { };

}
