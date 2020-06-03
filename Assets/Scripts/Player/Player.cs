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
    public int maxScore;

    private int lives;
    private bool gameOver;
    private int score;

    private void Awake()
    {
        score = maxScore;

    }

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


    public Projectile GetProjectile()
    {
        return projectile;
    }

    public GameObject GetFiringPoint()
    {
        return firingPoint;
    }

    public void AddScore(int howMuch)
    {
        score += howMuch;
    }

    public void ReduceScore(int howMuch)
    {
        score -= howMuch;
    }

    public int GetLives() => lives;
    public bool GetGameOver() => gameOver;
    public int GetScore() => score;
}
