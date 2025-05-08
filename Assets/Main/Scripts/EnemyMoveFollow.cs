using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveFollow : MonoBehaviour
{
    Transform playerTrans;
    NavMeshAgent nav;
    void Start()
    {
        playerTrans = GameObject.Find("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(playerTrans.position);
    }
}
