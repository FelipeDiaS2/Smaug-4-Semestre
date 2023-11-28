using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PitCollector : MonoBehaviour
{
    private bool pit = true;
    private static bool hasGot = false;
    public Transform positionWater;
    public GameObject water;
    public Sprite[] sprites;
    public float cd;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[0];
        pit = true;
    }
    void Update()
    {
       if(cd > 0)
        {
            cd -= Time.deltaTime;
            if (cd <= 0)
            {
                GetComponent<SpriteRenderer>().sprite = sprites[0];
                Instantiate(water, positionWater.position, Quaternion.identity);
                pit = true;
                print("voltou");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("OIIII");
        }
        if (other.gameObject.CompareTag("Player") && pit == true)
        {
            if (Input.GetKey(KeyCode.F))
            {
                GetComponent<SpriteRenderer>().sprite = sprites[1];
                pit = false;
                cd = 5;
                print("acabou :c");
            }
            
        }
    }
}
