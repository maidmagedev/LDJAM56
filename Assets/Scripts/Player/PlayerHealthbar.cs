using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Image healthbar;
    [SerializeField] TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "HP: " + playerHealth.currHealth.ToString();
        healthbar.fillAmount = (float) Mathf.Lerp(0f, 1, playerHealth.currHealth / playerHealth.maxHealth);
        //Debug.Log(Mathf.Lerp(0, playerHealth.maxHealth, playerHealth.currHealth / playerHealth.maxHealth));
    }
}
