using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject IslandPrefab;
    public GameObject WaterPrefab;
    public Vector2 gridSize = new Vector2(50, 20);
    public float tileWidth = 1.0f;
    public float tileHeight = 1.0f;
    public float noiseScale = 0.1f; // Adjust to change frequency of noise
    public float threshold = 0.5f;  // Adjust to increase/decrease land mass

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                float noiseValue = Mathf.PerlinNoise(x * noiseScale, y * noiseScale);

                Vector3 spawnPosition = new Vector3(x * tileWidth, 0, y * tileHeight);
                if (noiseValue > threshold)
                {
                    Instantiate(IslandPrefab, spawnPosition, Quaternion.identity, transform);
                }
                else
                {
                    Instantiate(WaterPrefab, spawnPosition, Quaternion.identity, transform);
                }
            }
        }
    }
}
