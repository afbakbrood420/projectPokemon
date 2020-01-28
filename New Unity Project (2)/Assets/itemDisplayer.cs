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

    public void setItem(Item newItem, int newAmount)
    {
        item = newItem;
        amount = newAmount;
        nameText.text = item.name;
        amountText.text = amount.ToString() + "X";
        image.sprite = item.sprite;
        btn.onClick.AddListener(findTarget);
    }
    void findTarget()
    {
        
    }
}
