using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameObject player;
        float time;
        bool bInRange;

        void Start()
        {
            player = GameObject.Find("Player");
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject == player)
            {
                bInRange = true;
                Debug.Log("공격 성공");
            }     
        }
        private void OnTriggerExit(Collider other) 
        {
            if(other.gameObject == player)
            {
                bInRange = false;
            }     
        }
        void Update()
        {
            
        }
}
