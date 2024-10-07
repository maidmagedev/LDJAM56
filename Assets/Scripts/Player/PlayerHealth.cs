using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Actor
{
    public PlayerAnimationEvents playerAnimationEvents;
    public float timeSinceTakingDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        InitialSetup();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceTakingDamage += Time.deltaTime;
    }

    public override void OnTakeDamage(float damage) {
        playerAnimationEvents.animator.CrossFade("takeDamage", 0, 0);
        timeSinceTakingDamage = 0.0f;
    }

    public override void OnDeath()
    {
        
    }
}
