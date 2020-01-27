using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="potion",menuName ="Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public int healing;
    public bool canRevive = false;
}
