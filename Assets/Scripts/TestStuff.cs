using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStuff : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // enemy.Damage(1);
            Debug.Log("P pressed");
            enemy.GetComponent<Enemy>().Damage(1);
        }
    }
}
