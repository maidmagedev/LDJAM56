using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Actor
{
    public PlayerAnimationEvents playerAnimationEvents;
    
    // Start is called before the first frame update
    void Start()
    {
        InitialSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnTakeDamage(float damage) {
        playerAnimationEvents.animator.CrossFade("takeDamage", 0, 0);
    }
}
