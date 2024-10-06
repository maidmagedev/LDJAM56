using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkull : Actor
{
    public override void OnTakeDamage(float damage)
    {
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitialSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
