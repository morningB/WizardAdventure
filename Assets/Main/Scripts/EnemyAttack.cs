using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameObject player;
    float time;
    bool bInRange;
    
    public float attackInterval = 1.0f;
    public int damage = 20;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player )
        {
            bInRange = true;
            Debug.Log("좀비의 공격 성공");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            bInRange = false;
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= attackInterval && bInRange)
        {
            time = 0;
            Debug.Log("좀비가 공격함");
            player.GetComponent<PlayerHealth>().Damage(damage);

            // if (player.GetComponent<PlayerHealth>().hp <= 0)
            // {
            //     GetComponent<Animator>().SetTrigger("Death");
            // }
        }
    }
}
