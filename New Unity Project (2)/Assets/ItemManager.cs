using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject itemPrefab;
    private List<Item> Items;
    private List<itemDisplayer> itemObjects = new List<itemDisplayer> { };
    private List<int> amounts;
    private int count;
    void Start()
    {
        Items = (GameObject.FindGameObjectWithTag("party").GetComponent("party") as party).items;
        amounts = (GameObject.FindGameObjectWithTag("party").GetComponent("party") as party).itemAmounts;
        count = 0;
        foreach (Item item in Items)
        {
            itemObjects.Add((Instantiate(itemPrefab, gameObject.transform).GetComponent("itemDisplayer") as itemDisplayer));
            itemObjects[count].setItem(item,amounts[count]);
            count = count + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
