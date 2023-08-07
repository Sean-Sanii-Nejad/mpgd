using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPreFab;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;

    void Update() {
        if(countdown <= 0) {
            SpawnWave();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    void SpawnWave() {

        for(int i = 0; i < waveIndex; i++) {

        }



        waveIndex++;
    }

    void SpawnEnemy() {
        Instantiate(enemyPreFab, transform.position, transform.rotation);
    }
}
