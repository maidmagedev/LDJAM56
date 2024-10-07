using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField] Material muzzleFlash;
    [SerializeField] Material hatchetSmear;
    public Animator animator;
    [SerializeField] PlayerOrientation playerOrientation;
    [SerializeField] PlayerAttackSystem playerAttackSystem;
    [SerializeField] Movement movement;
    bool muzzleHandler;
    bool smearHandler;
    [SerializeField] GameObject playerDamageTrigger;

    // Start is called before the first frame update
    void Start()
    {
        if (animator == null) {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MuzzleFlashHandler(int on) {
        if (on == 1) {
            SetAllowMovement(false);
            muzzleHandler = true;
            StartCoroutine(FlashHandlerCoroutine());
        } else {
            SetAllowMovement(true);
            muzzleHandler = false;
        }
    }

    IEnumerator FlashHandlerCoroutine() {
        playerOrientation.lookOverride = true;
        while(muzzleHandler) {
            playerOrientation.playerObj.LookAt(playerOrientation.cursor.position + new Vector3(0f, 1f, 0f));
            Color temp = muzzleFlash.color;
            temp.a = animator.GetFloat("MuzzleOpacity");
            muzzleFlash.color = temp;
            yield return new WaitForEndOfFrame();
        }
        playerOrientation.lookOverride = false;
    }

    void HatchetSmearHandler(int on) {
        if (on == 1) {
            smearHandler = true;
            SetAllowMovement(false);
            StartCoroutine(SmearHandlerCoroutine());
            StartCoroutine(PushPlayer(0.15f, 12));
        } else {
            SetAllowMovement(true);
            smearHandler = false;
        }
    }

    IEnumerator SmearHandlerCoroutine() {
        playerOrientation.lookOverride = true;
        while(smearHandler) {
            //playerOrientation.playerObj.LookAt(playerOrientation.cursor.position + new Vector3(0f, 1f, 0f));
            Color temp = hatchetSmear.color;
            temp.a = animator.GetFloat("SmearOpacity");
            hatchetSmear.color = temp;
            yield return new WaitForEndOfFrame();
        }
        playerOrientation.lookOverride = false;
    }

    void SetAllowMovement(bool on) {
        movement.allowMovement = on;
    }

    void SetAllowMovementI(int on) {
        if (on == 1) {
            movement.allowMovement = true;
        } else {
            movement.allowMovement = false;
        }
    }

    IEnumerator PushPlayer(float duration, float force) {
        float elapsedTime = 0.0f;
        while(elapsedTime < duration) {
            Vector3 flatLook = new Vector3(playerOrientation.playerObj.forward.x, 0, playerOrientation.playerObj.forward.z);
            playerOrientation.playerObj.LookAt(playerOrientation.cursor.position + new Vector3(0f, 1f, 0f));
            movement.rb.AddForce(force * flatLook.normalized, ForceMode.Impulse);

            elapsedTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    void SetAttackComboCount(int count) {
        animator.SetInteger("AttackComboCount", count);
    }

    void SetDamageTriggerActive(int setting) {
        playerDamageTrigger.SetActive(setting == 1);

    }

    void ToggleGunCanFire(int on) {
        playerAttackSystem.canFire = on == 1;
    }
}
