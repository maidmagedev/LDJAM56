using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cleric : Actor
{
    public PaladinBoss paladinBoss;
    public GameObject obj;
    public AudioSource audioSource;

    float channelTime = 20;
    bool pauseChannel = false;
    [SerializeField] TextMeshProUGUI textmesh;
    public override void OnDeath()
    {
        Destroy(obj);
    }

    public override void OnTakeDamage(float damage)
    {
        if (pauseChannel == false) {
            StartCoroutine(PauseOnDamage());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (paladinBoss == null) paladinBoss = FindObjectOfType<PaladinBoss>();
        InitialSetup();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseChannel) channelTime -= Time.deltaTime;
        textmesh.text = channelTime.ToString("F2");

        if (channelTime <= 0) {
            channelTime = 20;
            if (!paladinBoss.isAlive) return;
            // heal 2.5% of the boss' hp bar. 4 of them spawn, so this should heal the boss 10% if they are successful.
            paladinBoss.currHealth += paladinBoss.maxHealth * 0.025f;
            if (paladinBoss.currHealth > paladinBoss.maxHealth) {
                paladinBoss.currHealth = paladinBoss.maxHealth;
            }
            audioSource.Play();
        }
    }

    IEnumerator PauseOnDamage() {
        pauseChannel = true;
        yield return new WaitForSeconds(0.5f);
        pauseChannel = false;
    }
}
