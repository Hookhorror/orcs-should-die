using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    private int enemiesOnScreen;

    void Awake()
    {
        instance = this;
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
}
