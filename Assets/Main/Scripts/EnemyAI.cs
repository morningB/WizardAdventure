using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // 플레이어
    private NavMeshAgent agent;
    private Animator animator;

    public float followDistance = 10f;
    public float attackDistance = 2.5f;

    private enum State { Idle, Follow, Attack }
    private State currentState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        currentState = State.Idle;
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.position);

        // 상태 전이
        if (dist > followDistance)
            currentState = State.Idle;
        else if (dist > attackDistance)
            currentState = State.Follow;
        else
            currentState = State.Attack;

        // 상태별 행동
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
                transform.LookAt(target); // 공격 방향
                animator.SetBool("bMove", false);
                animator.SetBool("Attack", true);
                break;
        }
    }
}
