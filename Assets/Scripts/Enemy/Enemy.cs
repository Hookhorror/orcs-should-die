using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public float movementInterval;
    public float movementSpeedDown;
    public float movementSpeedSides;
    public float knockbackStrength;

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
            // Debug.Log(gameObject.ToString() + " died");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            // Debug.Log("ENEMY TOOK HIT");
            DealDamageToSelf(other);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("BottomWall"))
        {
            GameObject player = PlayerManager.instance.player;
            player.GetComponent<Player>().LoseLife();
            Destroy(gameObject);
            // Debug.Log("YOU LOST A LIFE | " + player.GetComponent<Player>().GetLives() + " LEFT");
            return;
        }
        if (other.rigidbody.CompareTag("Player"))
        {
            // Debug.Log(other.rigidbody.name);
            // Debug.Log("ENEMY HIT PLAYER");
            DealDamageToPlayer();
            Knockback(other.rigidbody);
        }

        // if (other.otherCollider.CompareTag("PlayerProjectile"))
        // {
        //     Debug.Log("ENEMY TOOK HIT");
        //     DealDamageToSelf(other.otherCollider);
        // }
    }

    private void DealDamageToPlayer()
    {
        // Debug.Log("DEALT DAMAGE TO PLAYER");
    }

    private void Knockback(Rigidbody2D rb)
    {
        rb.AddForce(Vector2.down * knockbackStrength
                                       , ForceMode2D.Impulse);
    }

    private void DealDamageToSelf(Collider2D collision)
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

    public float GetMovementSpeedDown()
    {
        return movementSpeedDown;
    }

    public float GetMovementSpeedSides()
    {
        return movementSpeedSides;
    }
}
