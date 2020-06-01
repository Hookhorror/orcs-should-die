using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    public int maxLives;
    private int lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoseLife()
    {
        lives--;
        if (lives < 1)
        {
            LostTheGame();
        }
    }

    private void LostTheGame()
    {
        Debug.Log("LOST THE GAME");
    }
}
