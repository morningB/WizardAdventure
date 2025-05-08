using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject weapon;
    public GameObject FireBall;
    
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WeaponPickUp")
        {
            weapon.SetActive(true);
            Destroy(other.gameObject);
        }
        if(other.tag == "FireBall")
        {
            // 스킬 획득
            Debug.Log("스킬 획득");
            Destroy(other.gameObject);
        }
    }
}
