using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType {
        Block,
        Tool,
        Gun,
        Wall,
        Decor,
        Machine,
        Clothing,
        Coin,
        Consumable
    }

    public ItemType itemType;
    public int amount;
    public int id;

    public Sprite GetSprite() {
        return ItemAssets.Instance.itemSprites[id];
    }
}
