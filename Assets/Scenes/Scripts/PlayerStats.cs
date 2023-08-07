using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public static int Money;
    public int startMoney = 100;

    public static int Health = 100;

    private void Start() {
        Money = startMoney; 
    }
}
