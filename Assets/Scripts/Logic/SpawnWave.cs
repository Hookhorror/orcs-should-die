using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public float spaceBetween;
    public int[] numberOfWavesAndRows;
    // public int numberOfRowsInWave;
    public Enemy[] wave;

    private int rowsSpawned;
    private int currentWave;

    // Start is called before the first frame update
    void Start()
    {
        // Spread();
        SpawnRows();
    }

    private void Update()
    {
        if (rowsSpawned >= 3 /* numberOfWavesAndRows[currentWave] */)
        {
            CancelInvoke("SpawnAndSpread");
            rowsSpawned = 0;
            Debug.Log("ALL ENEMIES SPAWNED IN CURRENT WAVE");
        }
    }

    private void SpawnRows()
    {
        Debug.Log("WAVE SPAWNING STARTED");
        InvokeRepeating("SpawnAndSpread", 3, 3);
    }

    private void SpawnAndSpread()
    {
        Enemy[] enemies = (Enemy[])wave.Clone();
        float addition = spaceBetween + 0.375f;

        if (wave.Length % 2 != 0)
        {
            Enemy enemy = Instantiate(enemies[enemies.Length - 1], Vector3.zero, Quaternion.identity);
            // Debug.Log(enemy.transform.position.x);
            addition = 2 * spaceBetween;
        }
        for (int i = 0; i < enemies.Length / 2; i++)
        {
            Enemy enemyLeft = Instantiate(enemies[i], new Vector3(gameObject.transform.position.x - (i + addition), gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            // Debug.Log(enemyLeft.transform.position.x);
            Enemy enemyRight = Instantiate(enemies[i], new Vector3(gameObject.transform.position.x + (i + addition), gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            // Debug.Log(enemyRight.transform.position.x);
            addition += spaceBetween;
        }
        rowsSpawned++;
    }
}
