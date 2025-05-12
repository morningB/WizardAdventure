using UnityEngine;

public class ShieldHealth : MonoBehaviour
{
    public int maxHp = 100;
    private int currentHp;
    public AudioClip audioClip;
    void Start()
    {
        currentHp = maxHp;
    }

    public void Damage(int amount)
    {
        currentHp -= amount;
        Debug.Log($"방패 체력: {currentHp}");
        
        if (currentHp <= 0)
        {
            GetComponent<AudioSource>().PlayOneShot(audioClip);
            Debug.Log("방패 파괴");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
       if(other.tag == "Attack")
       {
            Fireball fireball = other.GetComponent<Fireball>();
            if (fireball != null)
            {
                Damage(fireball.damage);
            }
            Destroy(other.gameObject); // 공격 오브젝트 제거
       }
        
    }
}
