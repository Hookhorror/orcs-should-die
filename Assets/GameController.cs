using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameController instance;

    void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public GameObject enemySpawner;
}
