using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;

    private int health;
    private bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        setHealthToMax();
        InvokeRepeating("Health", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private bool Dead()
    {
        return dead;
    }

    public void Damage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            dead = true;
            Debug.Log(gameObject.ToString() + " died");
            Destroy(gameObject);
        }
    }

    private void setHealthToMax()
    {
        health = maxHealth;
    }

    private int Health()
    {
        Debug.Log(health);
        return health;
    }
}
