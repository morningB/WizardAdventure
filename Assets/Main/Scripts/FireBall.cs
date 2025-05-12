using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damage = 25;
    public float lifeTime = 5f;
    public AudioClip audioClip;
    
    void Start()
    {
        Destroy(gameObject, lifeTime);
        SetSizeByDamage();
    }

    void SetSizeByDamage()
    {
        Vector3 size;
        float radius;

        if (damage <= 25)
        {
            size = Vector3.one * 0.1f;
            radius = 0.3f;
        }
        else if (damage <= 50)
        {
            size = Vector3.one * 0.3f;
            radius = 0.6f;
        }
        else
        {
            size = Vector3.one * 0.5f;
            radius = 1.0f;
        }

        transform.localScale = size;

        SphereCollider col = GetComponent<SphereCollider>();
        if (col != null)
            col.radius = radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Shield"))
        {
            ShieldHealth shield = other.GetComponent<ShieldHealth>();
            if (shield == null)
                shield = other.GetComponentInParent<ShieldHealth>();

            if (shield != null)
            {
                 GetComponent<AudioSource>().PlayOneShot(audioClip);
                shield.Damage(damage);
                Debug.Log("방패에 막힘");
            }

            Destroy(gameObject); // 방패에 막혀도 삭제
            return;
        }
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.Damage(damage);
            }
            // 이펙트 재생 후 파괴 가능
            Destroy(gameObject);
        }
        
    }
    void Update()
    {
        
        
    }
}
