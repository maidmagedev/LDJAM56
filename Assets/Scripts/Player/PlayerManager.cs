using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerOrientation playerOrientation;
    public PlayerAnimationEvents playerAnimationEvents;
    public PlayerAnimations playerAnimations;
    public PlayerAttackSystem playerAttackSystem;
    public Movement playerMovement;

    public Rigidbody rb;
    public Transform body;
}
