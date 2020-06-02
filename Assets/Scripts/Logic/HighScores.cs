using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    private void Awake()
    {
        string s = System.IO.File.ReadAllText(@"Data/highscores.dat");
        highScoreText.text = s;
    }
}
