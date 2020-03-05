using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exitInventoryButton : MonoBehaviour
{
    public Button btn;
    private party Party;

    /*
     * this handles the exiting of the inventory
     */

    private void Start()
    {
        btn.onClick.AddListener(exitInventory);  //set ip the button
        Party = GameObject.FindGameObjectWithTag("party").GetComponent<party>(); //get the party
    }
    public void exitInventory()
    {
        Debug.Log("exitingInventory");
        Party.exitInventory(null); //we hebben geen item gebruikt, dus dat blijft null
    }
    private void Update()
    {
        if (Input.GetButtonDown("Inventory")) //als de inventory knop nog een keer word ingedrukt, verlaat het scherm dan
        {
            exitInventory();
        }
    }
}
