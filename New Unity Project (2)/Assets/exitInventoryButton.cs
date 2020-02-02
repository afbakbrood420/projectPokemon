using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exitInventoryButton : MonoBehaviour
{
    public Button btn;
    private party Party;

    private void Start()
    {
        btn.onClick.AddListener(exitInventory);
        Party = GameObject.FindGameObjectWithTag("party").GetComponent<party>();
    }
    public void exitInventory()
    {
        Debug.Log("exitingInventory");
        Party.exitInventory();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            exitInventory();
        }
    }
}
