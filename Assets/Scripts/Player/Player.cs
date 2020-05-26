using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject firingPoint;
    public Projectile projectile;

    private void Start()
    {
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
