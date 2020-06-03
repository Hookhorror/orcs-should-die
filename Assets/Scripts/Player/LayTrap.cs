using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayTrap : MonoBehaviour
{
    private GameObject spikeTrap;

    private bool reloading;
    private bool canBuild;
    private Vector3 buildLocation;
    private GameObject currentTrapSpot;
    // Start is called before the first frame update
    void Start()
    {
        spikeTrap = GetComponent<Player>().GetSpikeTrap();
    }

    void Update()
    {
        canBuild = GetComponent<Player>().GetBuildStatus();
        buildLocation = GetComponent<Player>().GetBuildLocation();
        currentTrapSpot = GetComponent<Player>().GetCurrentTrapSpot();

        if (Input.GetAxisRaw("Fire2") > 0 && !reloading && canBuild)
        {
            SpawnTrap(buildLocation);
            reloading = true;
            Destroy(currentTrapSpot);
        }
        else if (Input.GetAxisRaw("Fire2") < 1)
        {
            reloading = false;
        }
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     Debug.Log("TRAP BUILD LOCATION ENTERED");
    //     canBuild = true;
    //     buildLocation = other.transform.position;
    // }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     Debug.Log("TRAP BUILD LOCATION EXITED");
    //     canBuild = false;
    // }


    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     // if ()
    //     if (Input.GetAxisRaw("Fire2") > 0 && !reloading)
    //     {
    //         SpawnTrap(other.transform.position);
    //         Destroy(other);
    //         reloading = true;
    //     }
    //     else if (Input.GetAxisRaw("Fire2") < 1)
    //     {
    //         reloading = false;
    //     }
    // }

    private void SpawnTrap(Vector3 position)
    {
        GameObject trap = Instantiate(spikeTrap, position, Quaternion.identity);
        // Rigidbody2D rb = p.GetComponent<Rigidbody2D>();
        // rb.AddForce(Vector2.up * projectileForce, ForceMode2D.Impulse);
    }
}
