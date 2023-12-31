using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPreFab_0;
    public Transform enemyPreFab_1;
    public Transform enemyPreFab_2;

    public float timeBetweenWaves = 5f;
    
    public Text indexDisplay;
    public Text nextDisplay;

    private int waveIndex = 0;
    private bool isSpawning = false;
    private bool wait = true;

    public void Increment()
    {
        if(isSpawning) return;
        wait = false;
        UpdateDisplay();
        waveIndex++;
    }

    void Update()
    {
        Debug.Log(waveIndex);
        if (!isSpawning && !wait)
        {
            switch (waveIndex)
            {
                case 1:
                    StartCoroutine(SpawnWave1());
                    break;
                case 2:
                    StartCoroutine(SpawnWave2());
                    break;
                case 3:
                    StartCoroutine(SpawnWave3());
                    break;
                default: 
                    StartCoroutine(SpawnWave4());
                    break;
            }
        }
    }

    private void UpdateDisplay()
    {
        indexDisplay.text = "Wave: " + waveIndex;
        nextDisplay.text = "Next Wave";
    }

    IEnumerator SpawnWave1()
    {
        PlayerStats.Rounds += 1;
        isSpawning = true;
        yield return SpawnEnemies(enemyPreFab_0, 8, 0.3f);
        yield return SpawnEnemies(enemyPreFab_1, 4, 0.6f);
        isSpawning = false;
        wait = true;
    }

    IEnumerator SpawnWave2()
    {
        PlayerStats.Rounds += 1;
        isSpawning = true;
        yield return SpawnEnemies(enemyPreFab_0, 2, 0.3f);
        yield return SpawnEnemies(enemyPreFab_1, 5, 0.5f);
        isSpawning = false;
        wait = true;
    }

    IEnumerator SpawnWave3()
    {
        PlayerStats.Rounds += 1;
        isSpawning = true;
        yield return SpawnEnemies(enemyPreFab_0, 0, 0.1f);
        yield return SpawnEnemies(enemyPreFab_1, 10, 0.5f);
        isSpawning = false;
        wait = true;
    }

    IEnumerator SpawnWave4()
    {
        PlayerStats.Rounds += 1;
        isSpawning = true;
        yield return SpawnEnemies(enemyPreFab_0, 30, 0.1f);
        yield return SpawnEnemies(enemyPreFab_1, 30, 0.5f);
        isSpawning = false;
    }

    IEnumerator SpawnEnemies(Transform enemyPrefab, int count, float delay)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(delay);
        }
    }
}
