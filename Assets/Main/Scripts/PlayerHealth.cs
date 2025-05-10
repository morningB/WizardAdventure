using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public int hp = 100;
    Vector3 posRespawn;
    public RawImage imgBar;
    private bool isPlayerDead = false;
    void Start()
    {
        posRespawn = transform.position; // 시작위치
    }

    public void SetHP(int value)
    {
        if(value <0 || value > 100)
        return;
        hp = value;
        imgBar.transform.localScale = new Vector3(hp/100.0f,1,1);
    }
    public void Respawn()
    {
        hp = 100;
        transform.position = posRespawn;
        GetComponent<Animator>().SetTrigger("Respawn");
        
        GetComponent<PlayerController>().enabled = true;
        GetComponent<PlayerAttack>().enabled = true;

        imgBar.transform.localScale = new Vector3(1,1,1);
    }
    public void Damage(int amount)
    {
        if(hp <= 0 || isPlayerDead) return;

        hp -= amount;
        Debug.Log("player : "+hp);
        imgBar.transform.localScale = new Vector3(hp / 100.0f, 1,1);
        
        if(hp <= 0)
        {
            isPlayerDead = true;
            GetComponent<Animator>().SetTrigger("Death");
            
            GetComponent<PlayerController>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            
            Invoke("Respawn", 3);
        }
    }

}
