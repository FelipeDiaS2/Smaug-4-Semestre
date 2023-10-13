using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{

    public InventoryManager inventoryManager;
    public Item item;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bool canAdd = inventoryManager.instance.AddItem(item);

            if (canAdd == true)
            {
                Destroy(gameObject);
            }
        }
    }

}
