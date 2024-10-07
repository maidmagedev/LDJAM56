using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Actor
{
    public PlayerAnimationEvents playerAnimationEvents;
    public float timeSinceTakingDamage;

    public GameObject death;
    
    // Start is called before the first frame update
    void Start()
    {
        InitialSetup();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceTakingDamage += Time.deltaTime;
    }

    public override void OnTakeDamage(float damage) {
        playerAnimationEvents.animator.CrossFade("takeDamage", 0, 0);
        timeSinceTakingDamage = 0.0f;
    }

    public override void OnDeath()
    {
        death.SetActive(true);
        StartCoroutine(ReloadTimer());
    }

    IEnumerator ReloadTimer() {
        yield return new WaitForSeconds(5f);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
