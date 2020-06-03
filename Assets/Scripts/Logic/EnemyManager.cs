using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    public GameObject enemySpawner;

    private int enemiesOnScreen;

    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (enemiesOnScreen < 0) AddEnemy();
    }

    public void AddEnemy()
    {
        enemiesOnScreen++;
        // Debug.Log("TOTAL ENEMIES: " + enemiesOnScreen);
    }

    public void RemoveEnemy()
    {
        enemiesOnScreen--;
    }

    public int GetEnemiesOnScreen() => enemiesOnScreen;
    public GameObject GetEnemySpawner() => enemySpawner;
}
