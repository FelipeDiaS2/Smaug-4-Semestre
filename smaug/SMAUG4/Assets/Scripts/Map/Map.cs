using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public static bool UpgradeLvl1;
    public Text BlockMessage;

    void Start()
    {
        UpgradeLvl1 = false;
    }

    public void GoFirstIsland()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoSecondIsland()
    {
        
    }

    public void GoToThirdIsland()
    {

    }

    public void GoToFourthIsland()
    {

    }

    public void GoToFifthIsland()
    {

    }

    public void GoToSixthIsland()
    {

    }

    public void GoToSeventhIsland()
    {

    }

    public void GoToEighthIsland()
    {

    }

    public void GoToTenthIsland()
    {

    }
}
