using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PaladinBoss : Actor
{

    [SerializeField] NavMeshAgent agent;
    [SerializeField] PlayerManager player;
    [SerializeField] Animator anim;

    [Header("Settings")]
    public bool lookAtPlayer;
    public Mode mode = Mode.idling;
    public enum Mode {
        idling,
        moving,
        attacking
    }

    float idlingTime;
    float targetIdleTime = 1.0f;
    public bool JumpAttackMovement;

    public override void OnTakeDamage(float damage)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        InitialSetup();
        player = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == Mode.idling) {
            idlingTime += Time.deltaTime;
            if (idlingTime > targetIdleTime) {
                idlingTime = 0;
                mode = Mode.moving;
            }
        }



        if (mode == Mode.moving) {
            lookAtPlayer = true;
            agent.SetDestination(player.body.position);
        }

        anim.SetFloat("Velocity", agent.velocity.magnitude);

        if (lookAtPlayer) LookAtPlayerHandler();
        
        if (mode == Mode.moving) {
            if (Mathf.Abs((transform.position - player.body.transform.position).magnitude) < 5) {
                
                DoAttack();
            }
        }
    }

    void LookAtPlayerHandler() {
        Vector3 direction = player.body.position - anim.transform.position;
        direction.y = 0;
        if (direction != Vector3.zero) {
            Quaternion q = Quaternion.LookRotation(direction);
            anim.transform.rotation = Quaternion.Lerp(anim.transform.rotation, q, 0.1f);
        }
    }

    IEnumerator JumpAttackHandler() {
        float elapsedTime = 0.0f;
        lookAtPlayer = true;
        agent.SetDestination(transform.position - transform.forward * 5f);
        Debug.Log("Walking backwards");
        yield return new WaitForSeconds(0.65f);
        agent.SetDestination(transform.position);
        yield return new WaitForSeconds(0.5f);
        float speed = agent.speed;

        while (elapsedTime < 0.7875) {
            Debug.Log("Following Player");
            agent.speed = 45;
            agent.SetDestination(player.body.position);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        lookAtPlayer = false;
        agent.speed = speed;
        agent.SetDestination(transform.position);

    }

    void DoAttack() {
        int attackNumber = Random.Range(minInclusive: 0, maxExclusive: 3);
        mode = Mode.attacking;
        //lookAtPlayer = false;
        Debug.Log("Random chose attack:" + attackNumber);
        switch (attackNumber) {
            case 0:
                anim.CrossFade("melee_swing", 0, 0);
                targetIdleTime = 3.0f;
                break;
            case 1:
                anim.CrossFade("attack_stomp", 0, 0);
                targetIdleTime = 1.0f;
                break;
            case 2:
                anim.CrossFade("melee_jump", 0, 0);
                StartCoroutine(JumpAttackHandler());
                targetIdleTime = 0.5f;
                break;
        }
    }
}
