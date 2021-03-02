// this script should be added as a component on enemy objects
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform player;
    private bool isAggro;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        isAggro = false;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < 10)
            isAggro = true;
        if (isAggro && !isDead)
            navMeshAgent.SetDestination(player.position);
    }
}
