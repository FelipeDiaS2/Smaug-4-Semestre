using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventoryManager instance;

    public GameObject inventoryItemPrefab;

    public InventorySlot[] inventorySlots;

    public void Awake()
    {
        instance = this; 
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InvetoryItem itemInSlot = slot.GetComponentInChildren<InvetoryItem>();

            if (itemInSlot == null)
            {
                SpawnItem(item, slot);
                return true ;
            }
        }
        return false ;
    }

    public void SpawnItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(inventoryItemPrefab, slot.transform);
        InvetoryItem inventoryItem = newItem.GetComponent<InvetoryItem>();
        inventoryItem.InitializeItem(item);
    }

}
