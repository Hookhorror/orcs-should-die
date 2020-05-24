using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float movement;
    private float movementInterval;
    // Start is called before the first frame update
    void Start()
    {
        movementInterval = GetComponentInParent<Enemy>().GetMovementInterval();
        StartMoving();
    }

    private void Move()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x
                                                  , gameObject.transform.position.y - movement);
    }

    private void StartMoving()
    {
        InvokeRepeating("Move", 1, movementInterval);
    }
}
