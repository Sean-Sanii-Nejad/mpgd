using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mages : MonoBehaviour
{
    public GameObject wizard1;
    public GameObject wizard2;

    public GameObject no1;
    public GameObject no2;


    public void SpawnWizard1()
    {
        if(PlayerStats.Money > 200)
        {
            if (wizard1.activeInHierarchy) { return; }
            PlayerStats.Money -= 200;
            wizard1.SetActive(true);
            no1.SetActive(true);
        }
        
    }
    public void SpawnWizard2()
    {
        if (PlayerStats.Money > 400) 
        {
            if (wizard2.activeInHierarchy) { return; }
            PlayerStats.Money -= 400;
            wizard2.SetActive(true);
            no2.SetActive(true);
        } 
    }
}
