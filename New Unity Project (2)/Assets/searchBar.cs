using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class searchBar : MonoBehaviour
{
    
    public InputField inputField;

    
    public Dropdown dropdown;

    private List<Dropdown.OptionData> dropdownOptions;

    /*
    this script is partially copied from: https://answers.unity.com/questions/1569855/search-in-dropdown-options.html
    and makes sure that the search bar works
    */
    private void Start()
    {
        dropdownOptions = dropdown.options;
    }

    //this method is called when the text value from the input field has been changed.
    public void FilterDropdown(string input)
    {  
        //this makes sure that the searchbar selects the first hit from a search case.
        dropdown.value = dropdownOptions.IndexOf((dropdownOptions.FindAll(option => option.text.ToLower().IndexOf(input.ToLower()) >= 0))[0]);
    }
}