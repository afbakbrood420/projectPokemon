using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public showHide showHide;

    private List<Item> Items;
    private List<itemDisplayer> itemObjects = new List<itemDisplayer> { };
    private List<int> amounts;
    private int count;
    private party Party;
    private Item chosenItem;

    void Start()
    {
        Party = (GameObject.FindGameObjectWithTag("party").GetComponent("party") as party);
        Items = Party.items;
        amounts = Party.itemAmounts;
        count = 0;

        foreach (Item item in Items)
        {
            itemObjects.Add((Instantiate(itemPrefab, gameObject.transform).GetComponent("itemDisplayer") as itemDisplayer));
            //makes a copy of the prefab for each item and make it a child of this object, and stores it in the list. 
            itemObjects[count].setItem(item,amounts[count]); //makes sure the amount is displayed and the prefab knows which item it holds
            count = count + 1;
        }
    }

    public void chooseItem(Item item) 
    {
        chosenItem = item;
        showHide.show(); //makes the target finder appear, so the player can choose what pokemon it wants to revive
    }
    public void chooseTarget(int index)
    {
        showHide.hide();
        Party.applyItem(chosenItem,index); //makes the party handle the item
    }
}
