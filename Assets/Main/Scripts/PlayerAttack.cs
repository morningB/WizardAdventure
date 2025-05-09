using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    float timer;
    LineRenderer line;
    Transform shootPoint;
    
    void Start()
    {
        line = GetComponent<LineRenderer>();
        shootPoint = transform.Find("ShootPoint");
    }
    public void Fire()
    {
        Ray ray = new Ray(shootPoint.position, shootPoint.forward);
        RaycastHit hit;

        timer = 0;
        
        GetComponent<Animator>().SetTrigger("Attack");
        GetComponent<Animator>().SetBool("bMove", true);
        if(Physics.Raycast(ray,out hit, 100, LayerMask.GetMask("Shootable")))
        {
            // 방패에 맞았는지 확인
            if (hit.collider.CompareTag("Shield"))
            {
                Debug.Log("방패에 막힘!");
                return; // 데미지 무효
            }
            EnemyHealth e = hit.collider.GetComponent<EnemyHealth>();
            if(e != null)
            {
                e.Damage(50);
                
            }

            line.enabled = true;
            line.SetPosition(0, shootPoint.position);
            line.SetPosition(1,hit.point);
          
        }
        else
        {
            line.enabled = true;
            line.SetPosition(0, shootPoint.position);
            line.SetPosition(1,shootPoint.position + ray.direction * 100);
          
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
        if(line.enabled)
        {
            timer += Time.deltaTime;
            if(timer > 0.05f)
            {
                line.enabled =false;
                
                //GetComponent<Light>().enabled = true;
            }
        }
        
       // GetComponent<Light>().enabled = false;
    }
}
