using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemDisplayer : MonoBehaviour
{
    public Item item;
    public int amount;
    public Text nameText;
    public Text amountText;
    public Image image;
    public Button btn;

    /*
     * handles UI of the item displayer prefab
     */

    public void setItem(Item newItem, int newAmount)
    {
        item = newItem; 
        amount = newAmount;
        nameText.text = item.name;
        amountText.text = amount.ToString() + "X"; //sets the item amount
        image.sprite = item.sprite;
        btn.onClick.AddListener(findTarget); //sets up the button
    }
    void findTarget()
    {
        GameObject.FindObjectOfType<ItemManager>().GetComponent<ItemManager>().chooseItem(item);
        //finds the itemmanager and calls the chooseItem method
    }
}
