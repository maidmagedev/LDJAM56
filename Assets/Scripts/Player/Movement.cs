using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [Header("Movement Settings")]
    [SerializeField] float movementForce;
    [SerializeField] float maxVelocity;
    [SerializeField] float jumpForce;
    [SerializeField] float groundDrag;


    [Header("References")]
    public Rigidbody rb;
    public float horizontalInput;
    public float verticalInput;
    public Transform orientation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();

        SpeedCap();
    }

    void FixedUpdate(){
        MovePlayer();
    }

    void MovePlayer() {
        Vector3 moveDirection = horizontalInput * orientation.right + verticalInput * orientation.forward;

        rb.AddForce(moveDirection * movementForce * 10, ForceMode.Force);
    }

    void InputHandler() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
    }

    void SpeedCap() {
        if (rb.velocity.magnitude > maxVelocity) {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }

}
