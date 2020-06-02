using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("GameOver");
        // Debug.Log("GAME OVER");
    }

    public int GetLives() => lives;
    public bool GetGameOver() => gameOver;

    public Projectile GetProjectile()
    {
        return projectile;
    }

    public GameObject GetFiringPoint()
    {
        return firingPoint;
    }
}
