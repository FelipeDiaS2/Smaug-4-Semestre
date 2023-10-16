using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CraftingStation : MonoBehaviour
{

    [SerializeField] private GameObject craftStation;
    [SerializeField] private GameObject mainInventoryGroup;
    [SerializeField] private RectTransform mainInventory;

    // Start is called before the first frame update
    void Start()
    {
        mainInventory = (RectTransform)mainInventoryGroup.transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO fix em não abrir o menu quando estiver no craft e fechar craft ui no mesmo botão
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.F)) 
            { 
                craftStation.gameObject.SetActive(true);
                mainInventoryGroup.gameObject.SetActive(true);
                mainInventory.anchoredPosition = new Vector3(-352, 44, 0);
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        craftStation.gameObject.SetActive(false);
        mainInventory.anchoredPosition = new Vector3(0, 44, 0);
        mainInventoryGroup.gameObject.SetActive(false);
    }
}
