using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    
void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("게임 클리어!");
            SceneManager.LoadScene("Victory");
            
        }
    }
}
