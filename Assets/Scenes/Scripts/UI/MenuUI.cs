using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public GameObject turrets;
    public GameObject mages;


    public void SelectTurrets()
    {
        turrets.SetActive(true);
        mages.SetActive(false);     
    }
    public void SelectMages()
    {
        turrets.SetActive(false);
        mages.SetActive(true);
    }




}
