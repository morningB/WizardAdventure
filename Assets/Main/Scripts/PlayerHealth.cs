using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public int hp = 100;
    public int entireHp = 3;

    public GameObject[] lifeIcons; // UI에서 3개의 생명 아이콘을 할당
    Vector3 posRespawn;
    public RawImage imgBar;
    private bool isPlayerDead = false;
    public Slider sliderHP;
    public AudioClip audioClip;
    void Start()
{
    posRespawn = transform.position;

    if (sliderHP != null)
    {
        sliderHP.value = hp;
    }
}

    public void SetHP(int value)
    {
        if(value <0 || value > 100)
        return;
        hp = value;
        imgBar.transform.localScale = new Vector3(hp/100.0f,1,1);
        sliderHP.value = hp;
    }
    public void Respawn()
    {
        if(entireHp > 0)
        {
            hp = 100;
            entireHp--;
            // 생명 아이콘 제거
            if (entireHp < lifeIcons.Length && lifeIcons[entireHp] != null)
                lifeIcons[entireHp].SetActive(false);

            transform.position = posRespawn;
            GetComponent<Animator>().SetTrigger("Respawn");
            GetComponent<AudioSource>().PlayOneShot(audioClip);
            GetComponent<PlayerController>().enabled = true;
            GetComponent<PlayerAttack>().enabled = true;

            imgBar.transform.localScale = new Vector3(1,1,1);
            sliderHP.value = hp;
            isPlayerDead = false;
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }
    public void Damage(int amount)
    {
        if(hp <= 0 || isPlayerDead) return;

        hp -= amount;
        Debug.Log("player : "+hp);
        imgBar.transform.localScale = new Vector3(hp / 100.0f, 1,1);
        sliderHP.value = hp;
        
        
        if(hp <= 0)
        {
            isPlayerDead = true;
            GetComponent<Animator>().SetTrigger("Death");
            
            GetComponent<PlayerController>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            
            Invoke("Respawn", 2);
        }
    }

}
