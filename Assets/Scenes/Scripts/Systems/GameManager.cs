using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject gameOverUI;

    private void Start()
    {
        GameIsOver = false;
    }

    private void Update()
    {
        if(GameIsOver) return;   

        if(PlayerStats.Health <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
