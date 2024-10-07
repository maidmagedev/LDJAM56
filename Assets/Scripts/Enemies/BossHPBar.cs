using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    [SerializeField] PaladinBoss paladinBoss;
    [SerializeField] Image healthbar;
    [SerializeField] TextMeshProUGUI tmp_Health;

    // Update is called once per frame
    void Update()
    {
        tmp_Health.text = "BOSS HEALTH: " + paladinBoss.currHealth.ToString();
        healthbar.fillAmount = (float) Mathf.Lerp(0f, 1, paladinBoss.currHealth / paladinBoss.maxHealth);
    }
}
