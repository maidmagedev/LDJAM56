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
    public Transform facingDirection;
    
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
        Vector3 moveDirection = verticalInput * orientation.forward + horizontalInput * orientation.right;
        if (moveDirection == Vector3.zero) {
            return;
        } else {
            facingDirection.forward = moveDirection;
        }

        rb.AddForce(moveDirection.normalized * (10 * movementForce), ForceMode.VelocityChange);
    }

    void InputHandler() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
    }

    void SpeedCap() {
        Vector3 flatvelocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        if (rb.velocity.magnitude > maxVelocity) {
            Vector3 cappedVelocity = rb.velocity.normalized * maxVelocity;
            rb.velocity = cappedVelocity;
        }
    }

}
