using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float movementInterval;
    private float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        movementInterval = GetComponentInParent<Enemy>().GetMovementInterval();
        movementSpeed = GetComponentInParent<Enemy>().GetMovementSpeed();
        StartMoving();
    }

    private void Move()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x
                                                  , gameObject.transform.position.y - movementSpeed);
    }

    private void StartMoving()
    {
        InvokeRepeating("Move", 1, movementInterval);
    }
}
