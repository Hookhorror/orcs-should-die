using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        force = GetComponent<Player>().GetProjectileForce();
        damage = GetComponent<Player>().GetProjectileDamage();
    }
}
