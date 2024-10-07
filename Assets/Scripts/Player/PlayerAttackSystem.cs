using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    public Transform cursor;
    public LayerMask damagedLayer;
    public PlayerAnimations playerAnimations;
    public Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        if (cursor == null) {
            cursor = FindObjectOfType<MousePositionHandler>().transform;
        }

        if (movement == null) movement = FindObjectOfType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, (cursor.position + new Vector3(0, 1, 0) - transform.position).normalized * 100, Color.red);
        if (Input.GetMouseButtonDown(0)) {
            if (movement.isDashing) return;
            Slash();
        }

        if (Input.GetMouseButtonDown(1)) {
            
            GunAction();

        }
    }

    void GunAction() {
        playerAnimations.anim.CrossFade("gun_fire", 0, 0);

        Debug.Log("Fire");
        RaycastHit hitInfo;
        Ray ray = new(transform.position, (cursor.position + new Vector3(0, 1, 0) - transform.position).normalized);
        if (Physics.Raycast(transform.position, (cursor.position + new Vector3(0, 1, 0) - transform.position).normalized, out hitInfo, 100, damagedLayer, QueryTriggerInteraction.UseGlobal)) {
            Debug.Log("Raycast hit");
            hitInfo.collider.transform.GetComponent<Actor>().TakeDamage(25);
        }
    }

    void Slash() {
        
        if (playerAnimations.anim.GetInteger("AttackComboCount") == 0) {
            playerAnimations.anim.SetInteger("AttackComboCount", 1);
            playerAnimations.anim.CrossFade("melee_atkA01", 0, 0);


        } else {
            Debug.Log("test");
            playerAnimations.anim.SetInteger("AttackComboCount", 2);
        }
    }
}
