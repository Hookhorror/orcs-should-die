using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float movementInterval;
    private float movementSpeedDown;
    private float movementSpeedSides;
    private Vector3 nextMovement;

    private bool down = true;
    private bool left = true;
    private bool right;
    // Start is called before the first frame update
    void Start()
    {
        movementInterval = GetComponentInParent<Enemy>().GetMovementInterval();
        movementSpeedDown = GetComponentInParent<Enemy>().GetMovementSpeedDown();
        movementSpeedSides = GetComponentInParent<Enemy>().GetMovementSpeedSides();

        StartMoving();
    }

    private void Move()
    {
        NextMovement();
        // gameObject.transform.position = new Vector3(gameObject.transform.position.x
        //                                           , gameObject.transform.position.y - movementSpeed);
    }

    private void NextMovement()
    {
        if (down)
        {
            GoDown();
            return;
        }
        if (left)
        {
            GoLeft();
            return;
        }
        if (right)
        {
            GoRight();
            return;
        }

    }

    private void GoRight()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + movementSpeedSides
                                                  , gameObject.transform.position.y);
        left = true;
        right = false;
        down = true;
    }

    private void GoLeft()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - movementSpeedSides
                                                  , gameObject.transform.position.y);
        left = false;
        right = true;
        down = true;
    }

    private void GoDown()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x
                                                  , gameObject.transform.position.y - movementSpeedDown);
        down = false;
    }

    private void StartMoving()
    {
        InvokeRepeating("Move", 1, movementInterval);
    }

    private void StopMoving()
    {
        CancelInvoke("Move");
    }
}
