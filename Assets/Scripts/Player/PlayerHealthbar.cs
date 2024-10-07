using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Movement movement;
    [SerializeField] PlayerAttackSystem playerAttackSystem;
    [SerializeField] Image healthbar;
    [SerializeField] TextMeshProUGUI tmp_Health;
    [SerializeField] TextMeshProUGUI tmp_Dashes;
    [SerializeField] TextMeshProUGUI tmp_Bullets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tmp_Health.text = "HP: " + playerHealth.currHealth.ToString();
        healthbar.fillAmount = (float) Mathf.Lerp(0f, 1, playerHealth.currHealth / playerHealth.maxHealth);
        //Debug.Log(Mathf.Lerp(0, playerHealth.maxHealth, playerHealth.currHealth / playerHealth.maxHealth));
        tmp_Dashes.text = "Dashes: " + movement.dashCount;

        if (playerAttackSystem.bullets > 0) {
            tmp_Bullets.text = "Bullets: " + playerAttackSystem.bullets;
        } else {
            tmp_Bullets.text = "Bullets: (Reloading: "+ playerAttackSystem.timeReloading.ToString("F2") + "s)";
        }
    }
}
