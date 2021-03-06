﻿using System;
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
    private bool enteredTrap;
    // Start is called before the first frame update
    void Start()
    {
        setHealthToMax();
        EnemyManager.instance.AddEnemy();
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
            EnemyManager.instance.RemoveEnemy();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // enteredTrap = true;
        int damage = 0;

        if (other.CompareTag("PlayerProjectile"))
        {
            damage = other.GetComponentInParent<Projectile>().GetDamage();
            // Debug.Log("ENEMY TOOK HIT FROM PROJECTILE");
        }
        if (other.CompareTag("Trap"))
        {
            bool cd = other.GetComponentInParent<SpikeTrap>().GetCooldown();
            if (!cd)
            {
                damage = other.GetComponentInParent<SpikeTrap>().GetDamage();
                Debug.Log("TRAP SPRUNG");
            }
        }
        DealDamageToSelf(damage);
    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     enteredTrap = false;
    // }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("BottomWall"))
        {
            GameObject player = PlayerManager.instance.player;
            player.GetComponent<Player>().LoseLife();
            EnemyManager.instance.RemoveEnemy();
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

    private void DealDamageToSelf(int damage)
    {
        // Debug.Log("ENEMY DAMAGED");
        ReduceHealth(damage);
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
