using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hp = 100;

    public void Damage(int amount)
    {
        if(hp <= 0)return;

        hp -= amount;
        Debug.Log("히트");

        
        if(hp <= 0 )
        {
            GetComponent<Animator>().SetTrigger("Death");
            
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject,1.5f);
            //GameObject.Find("GameManager").GetComponent<Spawn>().count--;
            
        }
    }
}
