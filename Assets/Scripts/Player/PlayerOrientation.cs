using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerOrientation : MonoBehaviour
{

    public Transform playerObj;
    public Transform cursor;
    public Movement movement;
    
    public Transform facingDirection;
    public bool lookOverride;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = Vector3.zero;
        
        Quaternion targetRotation = Quaternion.LookRotation(facingDirection.forward);
        if (!lookOverride) 
        {
            playerObj.rotation = targetRotation; // Quaternion.RotateTowards(playerObj.rotation, targetRotation, 5f * Time.deltaTime);
        }
    }
}
