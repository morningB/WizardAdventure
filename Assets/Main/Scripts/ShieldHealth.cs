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
        GetComponent<AudioSource>().PlayOneShot(audioClip);
        if (currentHp <= 0)
        {
            Debug.Log("방패 파괴");
            Destroy(gameObject);
        }
    }
}
