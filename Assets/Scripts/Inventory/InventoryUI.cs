using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    public Transform slotHeader;
    public Transform slotContainer;
    public Transform slotTemplate;

    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        Refresh();
    }

    private void Refresh() {
        int x = 0;
        int y = 0;
        float slotSize = 110f;
        float padding = 10f;
        foreach (Item item in inventory.GetItemList()) {
            RectTransform slotRect = Instantiate(slotTemplate, slotContainer).GetComponent<RectTransform>();
            slotRect.gameObject.SetActive(true);
            slotRect.anchoredPosition = new Vector2(x * slotSize + padding, y * -slotSize - padding);
            x++;
            Image itemImage = slotRect.GetChild(0).GetComponent<Image>();
            itemImage.sprite = item.GetSprite();
            if (x > 3) {
                x = 0;
                y++;
            }
        }
    }
}
