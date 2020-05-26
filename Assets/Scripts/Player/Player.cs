using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject firingPoint;
    public Projectile projectile;

    private void Start()
    {
        // Invoke("testi", 2);
    }

    private void testi()
    {
        this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100, ForceMode2D.Impulse);
    }

    public Projectile GetProjectile()
    {
        return projectile;
    }

    public GameObject GetFiringPoint()
    {
        return firingPoint;
    }
}
