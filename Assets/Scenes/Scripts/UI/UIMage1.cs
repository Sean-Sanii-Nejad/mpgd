using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMage1 : MonoBehaviour
{
    public Image image;
    public Color color_0;
    public Color color_1;

    void Start()
    {
        image = GetComponent<Image>();
        color_0 = Color.cyan;
        color_1 = Color.red;
    }

    void Update()
    {
        if (PlayerStats.Money >= 200)
        {
            image.color = color_0;
        }
        else
        {
            image.color = color_1;
        }

    }
}
