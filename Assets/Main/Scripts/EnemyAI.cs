using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Transform target; // �÷��̾�
    private NavMeshAgent agent;
    private Animator animator;

    public float followDistance = 10f;
    public float attackDistance = 1.5f;

    private enum State { Idle, Follow, Attack }
    private State currentState;

    void Start()
    {
        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        currentState = State.Idle;
    }

    void Update()
    {
        if(GetComponent<EnemyHealth>().isDead) return;
        
        if(target == null)
        {
            currentState = State.Idle;

            agent.isStopped = true;
            animator.SetBool("bMove", false);
            animator.SetBool("Attack", false); // 애니메이션 재생 방지
            return;
        }
        else{
            float dist = Vector3.Distance(transform.position, target.position);

        // 
        if (dist > followDistance)
            currentState = State.Idle;
        else if (dist > attackDistance)
            currentState = State.Follow;
        else
            currentState = State.Attack;

        
        }
        
        switch (currentState)
        {
            case State.Idle:
                agent.isStopped = true;
                animator.SetBool("bMove", false);
                break;

            case State.Follow:
                agent.isStopped = false;
                agent.SetDestination(target.position);
                animator.SetBool("bMove", true);
                animator.SetBool("Attack", false);
                break;

            case State.Attack:
                agent.isStopped = true;
                transform.LookAt(target); 
                animator.SetBool("bMove", false);
                animator.SetBool("Attack", true);
                break;
        }
    }
}
