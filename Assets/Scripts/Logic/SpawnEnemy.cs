using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1, 3);
        // Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Spawn()
    {
        // Enemy enemy = new Enemy();
        Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
        MoveToLeft(enemy);
    }

    private void MoveToLeft(Enemy item)
    {
        item.transform.position = new Vector3(item.transform.position.x - 1f
                                            , item.transform.position.y);
    }
}
