using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject firingPoint;
    public Projectile projectile;
    public int maxLives;

    private int lives;
    private bool gameOver;

    private void Start()
    {
        lives = maxLives;
    }

    public void LoseLife()
    {
        lives--;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOver = true;
        // Debug.Log("GAME OVER");
    }

    public int GetLives() => lives;

    public Projectile GetProjectile()
    {
        return projectile;
    }

    public GameObject GetFiringPoint()
    {
        return firingPoint;
    }
}
