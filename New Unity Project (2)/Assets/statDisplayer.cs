using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statDisplayer : MonoBehaviour
{
    public Text stat;
    public Text value;

    /*
     * this script makes sure that the stat displayers are compatible with commands
    */
    public void setValue(int newValue)
    {
        value.text = newValue.ToString();
    }
    public void setStat(string statName)
    {
        stat.text = statName;
    }
}
