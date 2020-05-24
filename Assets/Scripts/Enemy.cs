using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public float movementInterval;

    private int health;
    private bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        setHealthToMax();
        // InvokeRepeating("Health", 1, 1);
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

    private int GetHealth()
    {
        // Debug.Log(health);
        return health;
    }

    public float GetMovementInterval()
    {
        return movementInterval;
    }
}
