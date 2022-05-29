using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] int health = 50;

   void OnTriggerEnter2D(Collider2D other) { 
       if ((other.tag == "Wall") && (gameObject.tag == "Bullet")) {
           Destroy(gameObject);
       }
       DamageDealer damage = other.GetComponent<DamageDealer>();
       if (damage != null)
        {
            if (gameObject.tag == other.tag) {
                // skip
            } else {
                TakeDamage(damage.getDamage());
                damage.Hit();
            }
        }
    }

    void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
