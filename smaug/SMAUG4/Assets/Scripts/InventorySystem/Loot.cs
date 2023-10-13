using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item item;

    [SerializeField] private GameObject buttonPress;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            buttonPress.gameObject.SetActive(true);

            if (Input.GetKey(KeyCode.F))
            {
                bool canAdd = inventoryManager.instance.AddItem(item);

                if (canAdd == true)
                {
                    Destroy(gameObject);
                    print("coletou");
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        buttonPress.gameObject.SetActive(false);
    }

}



