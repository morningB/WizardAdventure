using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject weapon;
    public bool isPowerUp = false;
    public bool isGet = false;
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WeaponPickUp")
        {
            weapon.SetActive(true);
            isGet = true;
            Destroy(other.gameObject);
        }
        if(other.tag == "FireBall")
        {
            // 스킬 획득
            Debug.Log("스킬 획득");
            isPowerUp = true;
            Destroy(other.gameObject);
        }
        if(other.tag == "Key")
        {
            // 스킬 획득
            Debug.Log("Key 획득");
            GameManager.instance.AddKey();
            Destroy(other.gameObject);
        }
    }
}
