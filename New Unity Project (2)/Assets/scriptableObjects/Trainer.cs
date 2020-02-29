using System.Collections;
using System.Collections.Generic;
using UnityEngine;





[CreateAssetMenu(fileName = "newtrainer", menuName = "Trainer")]

public class Trainer : ScriptableObject
{
    public List<Pokemon> pokemons = new List<Pokemon> { };
    public new string name;
    public AudioClip trainerTheme;

}
