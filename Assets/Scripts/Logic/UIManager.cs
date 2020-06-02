using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI lifeCount;
    // Start is called before the first frame update
    void Start()
    {
        UpdateLifeCount();
        UpdateHighScores();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLifeCount();
    }

    private void UpdateLifeCount()
    {
        int lives = PlayerManager.instance.player.GetComponent<Player>().GetLives();
        // bool gameover = PlayerManager.instance.player.GetComponent<Player>().GetGameOver();
        lifeCount.text = "" + lives;
    }

    private void UpdateHighScores()
    {
        string s = System.IO.File.ReadAllText(@"Data/highscores.dat");
        Debug.Log(s);
    }
}
