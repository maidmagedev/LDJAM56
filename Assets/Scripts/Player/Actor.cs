using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public float currHealth = 0;
    public float maxHealth = 0;
    public bool isAlive = true;

    void Start() {
        InitialSetup();
    }

    public void InitialSetup() {
        currHealth = maxHealth;
    }

    public void TakeDamage(float damage) {
        Debug.Log("damage taken: " + damage);
        currHealth -= damage;


        if (currHealth <= 0 && isAlive) {
            Die();
        }
    }

    public void Die() {
        Debug.Log("die");
        isAlive = false;
    }
}
