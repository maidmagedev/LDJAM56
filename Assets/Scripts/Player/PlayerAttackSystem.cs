using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    public Transform cursor;
    public LayerMask damagedLayer;
    public PlayerAnimations playerAnimations;
    // Start is called before the first frame update
    void Start()
    {
        if (cursor == null) {
            cursor = FindObjectOfType<MousePositionHandler>().transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, (cursor.position + new Vector3(0, 1, 0) - transform.position).normalized * 100, Color.red);

        if (Input.GetMouseButtonDown(0)) {
            
            playerAnimations.anim.CrossFade("gun_fire", 0, 0);

            Debug.Log("Fire");
            RaycastHit hitInfo;
            Ray ray = new(transform.position, (cursor.position + new Vector3(0, 1, 0) - transform.position).normalized);
            if (Physics.Raycast(transform.position, (cursor.position + new Vector3(0, 1, 0) - transform.position).normalized, out hitInfo, 100, damagedLayer, QueryTriggerInteraction.UseGlobal)) {
                Debug.Log("Raycast hit");
                hitInfo.collider.transform.GetComponent<Actor>().TakeDamage(25);
            }

            
        }
    }
}
