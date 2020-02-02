using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    private party Party;
    private void Start()
    {
        Party = GameObject.FindObjectOfType<party>().GetComponent<party>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            Debug.Log("accesInventory");
            Party.accesInventory();
        }
    }
}
