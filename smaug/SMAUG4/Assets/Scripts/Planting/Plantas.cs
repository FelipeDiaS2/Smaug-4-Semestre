using Assets.Scripts.Planting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plantas : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Transform positionPlant;
    public GameObject[] seeds;
    public GameObject[] plants;
    private float timeGrow;
    private bool timeOn = false;
    private bool canPlant = true;
    private string name;
    [SerializeField] private GameObject buttonPress;


    private void Update()
    {
        Growing();
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && canPlant && !other.gameObject.CompareTag("item") && !other.gameObject.CompareTag("Item"))
        {
            buttonPress.gameObject.SetActive(true);

            if (Input.GetKey(KeyCode.F))
            {
                Planting();
            }

        }
        else
        {
            buttonPress.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        buttonPress.gameObject.SetActive(false);
    }

    private void Planting()
    {
        string seed = inventoryManager.SelectItem();
        print(seed);

        if (seed == "Semente-Batata")
        {
            Instantiate(seeds[0], positionPlant.position, Quaternion.identity);
            inventoryManager.GetSelectedItem(true);
            canPlant = false;
            timeGrow = 2;
            timeOn = true;
            name = "batata";
        }
        else if (seed == "Semente-Nabo")
        {
            Instantiate(seeds[1], positionPlant.position, Quaternion.identity);
            inventoryManager.GetSelectedItem(true);
            canPlant = false;
            timeGrow = 4;
            timeOn = true;
            name = "nabo";
        }
        else if(seed == "Semente-Erva")
        {
            Instantiate(seeds[2], positionPlant.position, Quaternion.identity);
            inventoryManager.GetSelectedItem(true);
            canPlant = false;
            timeGrow = 6;
            timeOn = true;
            name = "erva";
        }
    }

    public void Growing()
    {
        if (timeOn)
        {
            timeGrow -= Time.deltaTime;
            if (timeGrow <= 0 && name == "batata")
            {
                Instantiate(plants[0], positionPlant.position, Quaternion.identity);
                canPlant = true;
                timeOn = false;
            }
            else if (timeGrow <= 0 && name == "nabo")
            {
                Instantiate(plants[1], positionPlant.position, Quaternion.identity);
                canPlant = true;
                timeOn = false;
            }
            else if (timeGrow <= 0 && name == "erva")
            {
                Instantiate(plants[2], positionPlant.position, Quaternion.identity);
                canPlant = true;
                timeOn = false;
            }

        }
    }
 
}
