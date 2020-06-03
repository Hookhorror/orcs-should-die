using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public float spaceBetween;
    public float initialSpawnTime;
    public float SpawnTime;
    public int numberOfWaves = 1;
    public int trapsRewardedAfterWave;
    public int[] numberOfWavesAndRows;
    // public int numberOfRowsInWave;
    public Enemy[] wave;

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

            if (currentWave >= numberOfWaves)
            {
                wavesDone = true;
            }
            if (currentWave <= numberOfWaves && !wavesDone)
            {
                SpawnRows(SpawnTime);
            }
        }
        // Invoke("SpawnRows", 20);
    }

    // private void SpawnWaves()
    // {
    //     // InvokeRepeating("SpawnRows", 2, 20);
    //     Invoke("SpawnRows", 10f);
    // }

    // private void SpawnWavesStop()
    // {
    //     CancelInvoke("SpawnRows");
    //     // currentWave = 0;
    //     Debug.Log("WAVE SPAWNING STOPPED");
    //     PlayerManager.instance.player.GetComponent<Player>().AddTrapsAvailable(trapsRewardedAfterWave);
    // }

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
        PlayerManager.instance.player.GetComponent<Player>().AddTrapsAvailable(trapsRewardedAfterWave);

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

    public int GetCurrentWave() => currentWave;
    public int GetWaves() => numberOfWaves;

}
