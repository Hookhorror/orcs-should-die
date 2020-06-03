using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public int damage;
    public float cooldown;

    private bool onCooldown;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!onCooldown && other.CompareTag("Enemy"))
        {
            SpringTrap(other);
            Cooldown();
        }
    }

    private void Cooldown()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        Debug.Log("TRAP ON COOLDOWN");
        onCooldown = true;
        Invoke("ResetCooldown", cooldown);
    }

    private void ResetCooldown()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        Debug.Log("COOLDOWN RESETED");
        onCooldown = false;
    }

    private void SpringTrap(Collider2D other)
    {
        // if (other.CompareTag("Enemy"))
        {
            // other.attachedRigidbody()
        }
    }

    public int GetDamage() => damage;
    public bool GetCooldown() => onCooldown;
}
