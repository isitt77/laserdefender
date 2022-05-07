using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;


    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage();
            damageDealer.DiedByCollision();
        }
    }

    void TakeDamage()
    {
        DamageDealer damageDealer = FindObjectOfType<DamageDealer>();
        int damageTaken = damageDealer.GetDamage();
        health -= damageTaken;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
