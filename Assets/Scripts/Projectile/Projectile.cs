using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected int damage;
    protected float force;

    public int GetDamage()
    {
        return damage;
    }

    public float GetForce()
    {
        return force;
    }

}
