using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    public float damage;
    public bool damagePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) {
        
        if (col.gameObject.TryGetComponent<Actor>(out var a)) {
            if (damagePlayer && col.gameObject.CompareTag("Player")) {
                Debug.Log("Dealing damage");
                a.TakeDamage(damage);
            } else if (!damagePlayer && !col.gameObject.CompareTag("Player")) {
                Debug.Log("Dealing damage");
                a.TakeDamage(damage);
            }
        }
    }
}
