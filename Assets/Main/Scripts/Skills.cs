// using UnityEngine;

// public class Skills : MonoBehaviour
// {
//     public float damage = 50f;
//     public float lifeTime = 3f;

//     void Start()
//     {
//         Destroy(gameObject, lifeTime); // 자동 제거
//     }

//     void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Shield"))
//         {
//             ShieldHealth sh = other.GetComponent<ShieldHealth>();
//             if (sh == null)
//                 sh = other.GetComponentInParent<ShieldHealth>();

//             if (sh != null)
//             {
//                 Debug.Log("방패가 막음");
//                 sh.Damage((int)damage);
//             }

//             Destroy(gameObject);
//             return;
//         }

//         EnemyHealth eh = other.GetComponent<EnemyHealth>();
//         if (eh != null)
//         {
//             eh.Damage((int)damage);
//         }

//         Destroy(gameObject); // 명중 후 제거
//     }
// }
