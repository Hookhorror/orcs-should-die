using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject firingPoint;
    public Projectile projectile;
    public GameObject spikeTrap;
    public int maxLives;
    public int maxScore;
    public int initialTrapsAvailable;

    private int lives;
    private bool gameOver;
    private int score;
    private bool canBuild;
    private Vector3 buildLocation;
    private GameObject currentTrapSpot;
    private int trapsAvailable;

    private void Awake()
    {
        score = maxScore;

    }

    private void Start()
    {
        lives = maxLives;
        AddTrapsAvailable(initialTrapsAvailable);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (trapsAvailable > 0)
        {
            // Debug.Log("TRAP BUILD LOCATION ENTERED");
            canBuild = true;
            buildLocation = other.transform.position;
            currentTrapSpot = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log("TRAP BUILD LOCATION EXITED");
        canBuild = false;
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

    public GameObject GetSpikeTrap() => spikeTrap;

    public void AddScore(int howMuch)
    {
        score += howMuch;
    }

    public void ReduceScore(int howMuch)
    {
        score -= howMuch;
    }

    public void AddTrapsAvailable(int howMany)
    {
        trapsAvailable += howMany;
    }

    public void ReduceTrapsAvailable()
    {
        trapsAvailable--;
    }

    public int GetLives() => lives;
    public bool GetGameOver() => gameOver;
    public int GetScore() => score;
    public bool GetBuildStatus() => canBuild;
    public Vector3 GetBuildLocation() => buildLocation;
    public GameObject GetCurrentTrapSpot() => currentTrapSpot;
    public int GetTrapsAvailable() => trapsAvailable;

}
