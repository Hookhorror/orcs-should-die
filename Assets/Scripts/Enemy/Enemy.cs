using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public float movementInterval;
    public float movementSpeed;

    private int health;
    private bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        setHealthToMax();
    }

    private bool Dead()
    {
        return dead;
    }

    public void ReduceHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            dead = true;
            Debug.Log(gameObject.ToString() + " died");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            Debug.Log("ENEMY HIT");
            DealDamage(other);
        }
    }

    private void DealDamage(Collider2D collision)
    {
        Projectile p = null;
        try
        {
            p = collision.GetComponentInParent<Projectile>();
        }
        catch (System.Exception)
        {
            Debug.LogError("Something else than projectile collided with enemy");
            return;
        }
        ReduceHealth(p.GetDamage());
    }

    private void setHealthToMax()
    {
        health = maxHealth;
    }

    private int GetHealth()
    {
        return health;
    }

    public float GetMovementInterval()
    {
        return movementInterval;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }
}
