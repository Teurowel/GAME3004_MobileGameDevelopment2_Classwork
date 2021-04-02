using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public enum ZombieState
{
    IDLE,
    RUN,
    JUMP,
    PUNCH,
    DIE
}

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public PlayerBehaviour player;
    public Animator controller;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerBehaviour>();
        controller = GetComponent<Animator>();
        if (controller)
        {
            controller.SetInteger("AnimState", (int)ZombieState.RUN);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            navMeshAgent.SetDestination(player.transform.position);

            var distance = Vector3.Distance(player.transform.position, transform.position);

            //If the enemy is close enough to the player, perform an attack
            if(controller && (distance <= 3.0f))
            {
                LookAtPlayer();

                controller.SetInteger("AnimState", (int)ZombieState.PUNCH);
            }
        }
    }

    void LookAtPlayer()
    {
        Vector3 rot = Quaternion.LookRotation(player.transform.position - transform.position).eulerAngles;
        rot.x = rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);
    }
}
