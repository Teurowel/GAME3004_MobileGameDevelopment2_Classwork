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
        controller.SetInteger("AnimState", (int)ZombieState.RUN);
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            navMeshAgent.SetDestination(player.transform.position);
        }
    }
}
