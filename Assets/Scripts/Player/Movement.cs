using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public PlayerHealth playerHealth;

    public bool allowMovement = true;
    public bool isDashing;
    public int dashCount;
    
    // Start is called before the first frame update
    void Start()
    {
        if (playerHealth == null) playerHealth = FindObjectOfType<PlayerHealth>();
        
        dashCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
        SpeedCap();
    }

    void FixedUpdate(){
        if (allowMovement && !isDashing) {
            MovePlayer();
        }
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
        
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && dashCount > 0) {
            if (playerHealth.timeSinceTakingDamage < 1.0f) return;
            StartCoroutine(Dash());
        }
    }

    void SpeedCap() {
        if (isDashing) return;
        Vector3 flatvelocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        if (rb.velocity.magnitude > maxVelocity) {
            Vector3 cappedVelocity = rb.velocity.normalized * maxVelocity;
            rb.velocity = cappedVelocity;
        }
    }

    IEnumerator Dash() {
        dashCount--;
        isDashing = true;
        float elapsedTime = 0.0f;
        
        Vector3 moveDirection = verticalInput * orientation.forward + horizontalInput * orientation.right;
        playerHealth.invuln = true;
        if (moveDirection == Vector3.zero) moveDirection = facingDirection.forward;
        rb.AddForce(moveDirection.normalized * 35, ForceMode.Impulse);
        while (elapsedTime < 0.25f) {
            
            yield return new WaitForFixedUpdate();
            elapsedTime += Time.deltaTime;
        }
        playerHealth.invuln = false;
        isDashing = false;
        StartCoroutine(DashReturn());
    }

    IEnumerator DashReturn() {
        yield return new WaitForSeconds(2.75f);
        dashCount++;
    }
}
