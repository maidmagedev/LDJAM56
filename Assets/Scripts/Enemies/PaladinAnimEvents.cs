using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinAnimEvents : MonoBehaviour
{
    public PaladinBoss paladinBoss;
    public List<GameObject> colliders;
    void SetLookAtPlayer(int on) {
        paladinBoss.lookAtPlayer = (on == 1);
    }

    void SetMode(string mode) {
        switch(mode) {
            case "idling":
                paladinBoss.mode = PaladinBoss.Mode.idling;
                break;
            case "moving":
                paladinBoss.mode = PaladinBoss.Mode.moving;
                break;
            case "attacking":
                paladinBoss.mode = PaladinBoss.Mode.attacking;
                break;
        }
    }

    void SetDamageTriggerActive(int col) {
        colliders[col].SetActive(true);
    }

    void SetDamageTriggerInactive(int col) {
        colliders[col].SetActive(false);
    }

    void JumpAttackHandler() {
        
    }
}
