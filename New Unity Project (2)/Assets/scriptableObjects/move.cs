using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="scratch",menuName = "Move")]
public class move : ScriptableObject
{
    public int power;
    public int accuracy;
    public int pp;
    public bool isSpecial;
    public Type type;
}
