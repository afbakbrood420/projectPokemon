using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class searchBar : MonoBehaviour
{
    [SerializeField]
    private InputField inputField;

    [SerializeField]
    private Dropdown dropdown;

    private List<Dropdown.OptionData> dropdownOptions;

    private void Start()
    {
        dropdownOptions = dropdown.options;
    }
    public void FilterDropdown(string input)
    {
        dropdown.value = dropdownOptions.IndexOf((dropdownOptions.FindAll(option => option.text.ToLower().IndexOf(input.ToLower()) >= 0))[0]);
    }
}
