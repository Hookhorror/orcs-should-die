using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private GameObject firingPoint;
    private Projectile projectile;
    private float projectileForce;
    private float rateOfFire;
    private bool reloading;
    // private GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {

        firingPoint = GetComponent<Player>().GetFiringPoint();
        projectile = GetComponent<Player>().GetProjectile();
        projectileForce = projectile.GetForce();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Fire1") > 0 && !reloading)
        {
            SpawnPojectile();
            reloading = true;
        }
        else if (Input.GetAxisRaw("Fire1") < 1)
        {
            reloading = false;
        }
    }

    private void SpawnPojectile()
    {
        Projectile p = Instantiate(projectile, firingPoint.transform.position, Quaternion.identity);
        Rigidbody2D rb = p.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * projectileForce, ForceMode2D.Impulse);
    }
}
