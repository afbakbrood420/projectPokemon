using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class searchBar : MonoBehaviour
{
    public ScrollRect dropdownScroll;
    public Dropdown dropdown;
    public InputField input;
    private List<string> list = new List<string> { };
    private List<string> searchPosibilities = new List<string> { };

    void setPrePokemon(List<string> newList)
    {
        list = newList;
        input.onValueChanged.AddListener(testEvent);

    }

    private void testEvent(string arg0)
    {
        searchPosibilities.Clear();
        foreach (string option in list)
        {
            if (option.ToLower().Contains(arg0.ToLower()))
            {
                searchPosibilities.Add(option);
            }
        }
        Debug.Log(" posibilities: ");
        //try
        {
            dropdown.Show();
            dropdownScroll.verticalNormalizedPosition = (float)list.IndexOf(searchPosibilities[0]) / 5f;
        }
       // catch
        {
            Debug.Log("pokemon not found");
        }
        foreach (string opt in searchPosibilities)
        {
            Debug.Log(opt);
        }
    }
}
