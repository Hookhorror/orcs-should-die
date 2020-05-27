using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public Enemy[] wave;
    // Start is called before the first frame update
    void Awake()
    {
        /* Debug.Log("jee");
        for (int i = 0; i < wave.Length; i++)
        {
            Enemy enemy = Instantiate(wave[i], Vector3.right * (i * 2), Quaternion.identity);
            Debug.Log(enemy.transform.position.x);
        } */
        Spread();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Spread()
    {
        int addition = 1;

        if (wave.Length % 2 != 0)
        {
            Enemy enemy = Instantiate(wave[wave.Length - 1], Vector3.zero, Quaternion.identity);
            Debug.Log(enemy.transform.position.x);
            addition = 2;
        }
        for (int i = 0; i < wave.Length / 2; i++)
        {
            Enemy enemyLeft = Instantiate(wave[i], Vector3.left * (i + addition), Quaternion.identity);
            Debug.Log(enemyLeft.transform.position.x);
            Enemy enemyRight = Instantiate(wave[i], Vector3.right * (i + addition), Quaternion.identity);
            Debug.Log(enemyRight.transform.position.x);
            addition += 1;
        }
    }

    private int FindIndexOfMiddle()
    {
        if (wave.Length % 2 != 0)
        {
            return (wave.Length / 2) + 1;
        }
        return wave.Length / 2;
    }
}
