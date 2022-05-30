using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] int health = 50;

   AudioPlayer audio;
   ScoreValue scoreValue;
   ScoreKeeper keeper;
   

   void Start() {
       audio = GetComponent<AudioPlayer>();
       scoreValue = GetComponent<ScoreValue>();
       keeper = FindObjectOfType<ScoreKeeper>();
   }

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
        if (audio != null) {
            audio.PlayHitClip();
        }
        if (health <= 0) {
            Die();
        }
    }

    public int GetHealth() {
        return this.health;
    }

    public void SetHealth(int health) {
        this.health = health;
    }

    void Die() {
        if (audio != null) {
            audio.PlayDeathClip();
        }       
        if ((keeper != null) && (scoreValue != null)) {
            keeper.AddScore(scoreValue.GetScoreValue());
        }
        Destroy(gameObject);
    }
}
