using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public float spaceBetween;
    public int numberOfWaves;
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

    private void SpawnWaves()
    {
        // InvokeRepeating("Spread", 2, 2);
    }

    private void Spread()
    {
        // Enemy measurements = Instantiate(Enemy(), Vector3.zero, Quaternion.identity);
        float addition = spaceBetween + 0.375f;

        if (wave.Length % 2 != 0)
        {
            Enemy enemy = Instantiate(wave[wave.Length - 1], Vector3.zero, Quaternion.identity);
            Debug.Log(enemy.transform.position.x);
            addition = 2 * spaceBetween;
        }
        for (int i = 0; i < wave.Length / 2; i++)
        {
            Enemy enemyLeft = Instantiate(wave[i], new Vector3(gameObject.transform.position.x - (i + addition), gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            Debug.Log(enemyLeft.transform.position.x);
            Enemy enemyRight = Instantiate(wave[i], new Vector3(gameObject.transform.position.x + (i + addition), gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            Debug.Log(enemyRight.transform.position.x);
            addition += spaceBetween;
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
