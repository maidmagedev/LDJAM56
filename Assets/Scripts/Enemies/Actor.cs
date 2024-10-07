using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    public float currHealth = 0;
    public float maxHealth = 0;
    public bool isAlive = true;
    public bool onHitInvulnerability;
    public bool invuln;

    void Start() {
        InitialSetup();
    }

    public void InitialSetup() {
        currHealth = maxHealth;
    }

    public void TakeDamage(float damage) {
        if (onHitInvulnerability) return;
        if (invuln) return;
        OnTakeDamage(damage);
        Debug.Log("damage taken: " + damage);
        currHealth -= damage;
        StartCoroutine(OnHitInvulnerabilityHandler(0.25f));


        if (currHealth <= 0 && isAlive) {
            Die();
        }
    }

    IEnumerator OnHitInvulnerabilityHandler(float duration) {
        float elapsedTime = 0;
        onHitInvulnerability = true;
        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        onHitInvulnerability = false;
    }

    public abstract void OnTakeDamage(float damage);
    public abstract void OnDeath();

    public void Die() {
        Debug.Log("die");
        isAlive = false;
        OnDeath();
    }
}
