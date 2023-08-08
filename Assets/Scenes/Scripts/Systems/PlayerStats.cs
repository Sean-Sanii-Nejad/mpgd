using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public static int Money;
    public int startMoney = 100;

    public static int Health = 100;
    public static int Rounds;

    public static int EnemiesKilled;

    private void Start() {
        Money = startMoney;
        Rounds = 0;
        EnemiesKilled = 0;
    }
}
