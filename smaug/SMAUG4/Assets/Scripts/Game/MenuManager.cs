using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject mainInventory;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InventoryUi();
    }


    void InventoryUi()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            mainInventory.gameObject.SetActive(!mainInventory.gameObject.activeSelf);
        }

    }
}
