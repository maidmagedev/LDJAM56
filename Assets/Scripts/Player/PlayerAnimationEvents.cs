using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField] Material muzzleFlash;
    [SerializeField] Animator animator;
    [SerializeField] PlayerOrientation playerOrientation;
    bool muzzleHandler;

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
            muzzleHandler = true;
            StartCoroutine(FlashHandlerCoroutine());
        } else {
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
}
