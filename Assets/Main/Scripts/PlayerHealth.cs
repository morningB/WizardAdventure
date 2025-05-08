using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 100;
    Vector3 posRespawn;
    bool bDamage;
    void Start()
    {
        posRespawn = transform.position; // 시작위치
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Respawn()
    {
        hp = 100;
        transform.position = posRespawn;
        GetComponent<Animator>().SetTrigger("Respawn");
        
        GetComponent<PlayerController>().enabled = true;
        GetComponent<PlayerAttack>().enabled = true;
    }
    public void Damage(int amount)
    {
        if(hp <= 0) return;

        hp -= amount;

        bDamage = true;
        
        if(hp <= 0)
        {
            GetComponent<Animator>().SetTrigger("Death");

            GetComponent<PlayerController>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            
            Invoke("Respawn", 3);
        }
    }

}
