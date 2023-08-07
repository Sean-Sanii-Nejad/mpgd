using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text healthText;

    void Update()
    {
        healthText.text = "Health: "+PlayerStats.Money.ToString();
    }
}
