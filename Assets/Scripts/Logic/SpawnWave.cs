using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public float spaceBetween;
    public float initialSpawnTime;
    public float SpawnTime;
    public int[] numberOfWavesAndRows;
    // public int numberOfRowsInWave;
    public Enemy[] wave;
    public int numberOfWaves = 1;

    private int rowsSpawned;
    private int currentWave;
    private bool wavesDone;

    // Start is called before the first frame update
    void Start()
    {
        // Spread();
        SpawnRows(initialSpawnTime);
    }

    private void Update()
    {
        if (rowsSpawned >= 3/*  && currentWave <= numberOfWaves */ /* numberOfWavesAndRows[currentWave] */)
        {
            SpawnRowsStop();
            // SpawnRows();

            if (currentWave <= numberOfWaves && !wavesDone)
            {
                wavesDone = true;
                SpawnRows(SpawnTime);
            }
        }
        // Invoke("SpawnRows", 20);
    }

    private void SpawnWaves()
    {
        // InvokeRepeating("SpawnRows", 2, 20);
        Invoke("SpawnRows", 10f);
    }

    private void SpawnWavesStop()
    {
        CancelInvoke("SpawnRows");
        // currentWave = 0;
        Debug.Log("WAVE SPAWNING STOPPED");
    }

    private void SpawnRows(float waveSpawnTime)
    {
        currentWave++;
        Debug.Log("SPAWNING WAVE: " + currentWave);
        InvokeRepeating("SpawnAndSpread", waveSpawnTime, 3);
    }

    private void SpawnRowsStop()
    {
        CancelInvoke("SpawnAndSpread");
        rowsSpawned = 0;
        Debug.Log("WAVE " + currentWave + " SPAWNING STOPPED");

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
