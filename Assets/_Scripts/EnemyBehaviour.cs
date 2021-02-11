using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public PlayerBehaviour player;
    public NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }
}
