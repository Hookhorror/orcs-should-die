using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int movementSpeed;

    private Vector3 playerPosition;
    private Vector3 movementDirection;
    private Vector3 movement;

    private void Start()
    {
        playerPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");
        movementDirection = movementDirection.normalized;

        playerPosition = gameObject.transform.position;
        movement = movementDirection * movementSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(playerPosition
                                                   , playerPosition + movement
                                                   , 0.5f);
    }
}