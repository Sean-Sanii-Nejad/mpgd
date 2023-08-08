using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;
    public Text killedText;
    public GameObject gameOverUI;

    private void OnEnable()
    {
        roundsText.text = "Waves Survived: "+ (PlayerStats.Rounds-1).ToString();
        killedText.text = "Enemies Killed: "+ PlayerStats.EnemiesKilled.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
        PlayerStats.Health = 100;
        PlayerStats.Rounds = 0;
        PlayerStats.Money = 220;
        gameObject.SetActive(false);
        GameManager.GameIsOver = false;
    }

    public void Menu()
    {
        
    }
}
