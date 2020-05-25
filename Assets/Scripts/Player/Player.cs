using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject firingPoint;
    public Projectile projectile;

    public Projectile GetProjectile()
    {
        return projectile;
    }

    public GameObject GetFiringPoint()
    {
        return firingPoint;
    }
}
