using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public bool isDead = false;
    public int hp = 100;
     public RawImage imgBar;
    public AudioClip acp;
    public AudioClip audioShield;
     public GameObject shieldObject; // Inspector에서 할당하거나 Start에서 Find

    public void Damage(int amount)
    {
        if(hp <= 0 || isDead)return;

         if (shieldObject != null && shieldObject.activeInHierarchy)
        {
            Debug.Log("방패가 있어서 대미지를 막음");
            GetComponent<AudioSource>().PlayOneShot(audioShield);
            return;
        }

        hp -= amount;
        imgBar.transform.localScale = new Vector3(hp/ 100.0f,1,1);
        Debug.Log("히트");

        
        if(hp <= 0 )
        {
            Scroe.score += 10;
            isDead = true;
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<AudioSource>().PlayOneShot(acp);
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject,1.5f);
            
            GameObject.Find("GameManager").GetComponent<Spawner>().count--;
            
        }
    }
}
