// this script should be added as a component on enemy objects
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeBehaviour : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform player;
    private Animator animator;
    private bool isAggro;
    public bool isDead;
    private bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        isAggro = false;
        isDead = false;
        canAttack = false;
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Jammo_Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // chase player if close
        if (Vector3.Distance(player.position, transform.position) < 10)
        {
            isAggro = true;
            animator.SetBool("isAggro", true);
        }
        // 
        if (Vector3.Distance(player.position, transform.position) < 3)
            {
                canAttack = true;
                animator.SetBool("canAttack", true);
            }
        else
        {
            canAttack = false;
            animator.SetBool("canAttack", false);
        }

        if (isAggro && !isDead)
            navMeshAgent.SetDestination(player.position);
    }

    public void SetDead()
    {
        isDead = true;
        animator.SetBool("isDead", true);
    }
}
