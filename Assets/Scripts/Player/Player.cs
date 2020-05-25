using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float projectileForce;
    public int projectileDamage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetProjectileForce()
    {
        return projectileForce;
    }

    public int GetProjectileDamage()
    {
        return projectileDamage;
    }
}
