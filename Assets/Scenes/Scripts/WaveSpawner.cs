using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPreFab_0;
    public Transform enemyPreFab_1;
    public Transform enemyPreFab_2;
    public Transform enemyPreFab_3;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;

    public GameObject[][] wave;

    private void Start() {
        wave = new GameObject[5][]; 
    }

    void Update() {
        if(countdown <= 0) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave() {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy() {
        Instantiate(enemyPreFab_0, transform.position, transform.rotation);
    }
}
