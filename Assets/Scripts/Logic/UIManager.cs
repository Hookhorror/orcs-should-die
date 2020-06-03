using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // public static UIManager instance;
    public TextMeshProUGUI lifeCount;
    public TextMeshProUGUI scoreCount;
    public TextMeshProUGUI enemiesRemaining;
    public TextMeshProUGUI trapsAvailable;
    public TextMeshProUGUI wavesLeft;


    // Start is called before the first frame update
    void Start()
    {
        UpdateLifeCount();
        UpdateHighScores();
        InitialScore();
        UpdateTrapsAvailable();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLifeCount();
        UpdateEnemiesRemaining();
        UpdateScore();
        UpdateTrapsAvailable();
        UpdateWavesLeft();
    }

    private void UpdateLifeCount()
    {
        int lives = PlayerManager.instance.player.GetComponent<Player>().GetLives();
        // bool gameover = PlayerManager.instance.player.GetComponent<Player>().GetGameOver();
        lifeCount.text = "" + lives;
    }

    private void InitialScore()
    {
        int score = PlayerManager.instance.player.GetComponent<Player>().GetScore();
        scoreCount.text = "Score: " + score;
    }

    private void UpdateScore()
    {
        if (EnemyManager.instance.GetEnemiesOnScreen() > 0)
        {
            PlayerManager.instance.player.GetComponent<Player>().ReduceScore(1);
            int score = PlayerManager.instance.player.GetComponent<Player>().GetScore();
            scoreCount.text = "Score: " + score;
        }
    }

    private void UpdateHighScores()
    {
        string s = System.IO.File.ReadAllText(@"Data/highscores.dat");
        Debug.Log(s);
    }

    private void UpdateEnemiesRemaining()
    {
        enemiesRemaining.text = "Enemies Remaining: " + EnemyManager.instance.GetEnemiesOnScreen();
    }

    private void UpdateTrapsAvailable()
    {
        trapsAvailable.text = "Traps Available: " + PlayerManager.instance.player.GetComponent<Player>().GetTrapsAvailable();
    }

    private void UpdateWavesLeft()
    {
        wavesLeft.text = "Wave: " + EnemyManager.instance.GetEnemySpawner().GetComponent<SpawnWave>().GetCurrentWave()
                       + "/"
                       + EnemyManager.instance.GetEnemySpawner().GetComponent<SpawnWave>().GetWaves();
    }

}
