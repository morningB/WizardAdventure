using UnityEditor.AssetImporters;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    float timer;
    LineRenderer line;
    Transform shootPoint;
    public GameObject FirBallEffect;
    public GameObject fireballPrefab;
      
    void Start()
    {
        line = GetComponent<LineRenderer>();
        shootPoint = transform.Find("ShootPoint");
  
    }
    public void Fire()
    {
         // 발사 애니메이션 트리거
        GetComponent<Animator>().SetTrigger("Attack");

        // 발사체 생성
        GameObject fireball = Instantiate(fireballPrefab, shootPoint.position, shootPoint.rotation);

        Fireball fb = fireball.GetComponent<Fireball>();
        if(GetComponent<Item>().isGet)
        {
            fb.damage = 50;
        }
        if(fb!= null)
        {
            if(GetComponent<Item>().isPowerUp)
            {
                fb.damage = 100;
                Instantiate(FirBallEffect, shootPoint.position, shootPoint.rotation);
                
            }
                
        }
        // 발사 방향으로 힘 주기
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb. linearVelocity = shootPoint.forward * 27f;
        }
        // Ray ray = new Ray(shootPoint.position, shootPoint.forward);
        // RaycastHit hit;
        
        // timer = 0;
        
        // GetComponent<Animator>().SetTrigger("Attack");
        // GetComponent<Animator>().SetBool("bMove", true);
        // if(Physics.Raycast(ray,out hit, 100, LayerMask.GetMask("Shootable")))
        // {
            
        //     if (hit.collider.CompareTag("Shield"))
        //     {
        //         Debug.Log("방패로 막음");

        //         // 자식에 맞았기 때문에 부모까지 올라가서 컴포넌트를 찾아야 함
        //         ShieldHealth sh = hit.collider.GetComponent<ShieldHealth>();
        //         if (sh == null)
        //             sh = hit.collider.GetComponentInParent<ShieldHealth>();

        //         if (sh != null)
        //         {
        //             Debug.Log("ShieldHealth 발견, 데미지 적용");
        //             // 
        //             sh.Damage(50);
        //         }
        //         else
        //         {
        //             Debug.Log("ShieldHealth를 찾지 못함");
        //         }

        //         return;
        //     }

        //     EnemyHealth e = hit.collider.GetComponent<EnemyHealth>();
        //     if(e != null)
        //     {
        //         e.Damage(50);
                
        //     }

        //     line.enabled = true;
        //     Color c = line.material.color;
        //     c.a = 0;
        //     line.material.color = c;
        //     line.SetPosition(0, shootPoint.position);
        //     line.SetPosition(1,hit.point);
            
          
        // }
        // else
        // {
        //     line.enabled = true;
        //     Color c = line.material.color;
        //     c.a = 0;
        //     line.material.color = c;
        //     line.SetPosition(0, shootPoint.position);
        //     line.SetPosition(1,shootPoint.position + ray.direction * 100);
        //     Instantiate(FirBallEffect,shootPoint.position,shootPoint.rotation);
        // }
        
    }
    //

    // Update is called once per frame
    void Update()
    {
        
        // if(line.enabled)
        // {
        //     timer += Time.deltaTime;
        //     if(timer > 0.05f)
        //     {
        //         line.enabled =false;
        //     }
        // }

    }
}
