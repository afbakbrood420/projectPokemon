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
            itemObjects[count].setItem(item,amounts[count]);
            count = count + 1;
        }
    }

    public void chooseItem(Item item)
    {
        chosenItem = item;
        showHide.show();
    }
    public void chooseTarget(int index)
    {
        showHide.hide();
        Party.applyItem(chosenItem,index);
        //Party.exitInventory();
    }
}
