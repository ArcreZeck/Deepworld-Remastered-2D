using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private List<Item> itemList;

    public Inventory() {
        itemList = new List<Item>();
        AddItem(new Item { itemType = Item.ItemType.Block, amount = 1, id = 1 });
        AddItem(new Item { itemType = Item.ItemType.Block, amount = 1, id = 2 });
        AddItem(new Item { itemType = Item.ItemType.Block, amount = 1, id = 3 });
        AddItem(new Item { itemType = Item.ItemType.Block, amount = 1, id = 4 });
        AddItem(new Item { itemType = Item.ItemType.Block, amount = 1, id = 5 });
        AddItem(new Item { itemType = Item.ItemType.Block, amount = 1, id = 6 });
        AddItem(new Item { itemType = Item.ItemType.Block, amount = 1, id = 7 });
        AddItem(new Item { itemType = Item.ItemType.Block, amount = 1, id = 8 });
        Debug.Log("Added Item, itemList Count: " + itemList.Count);
    }

    public void AddItem(Item item) {
        itemList.Add(item);
    }

    public List<Item> GetItemList() {
        return itemList;
    }
}
