using UnityEngine;

public class Victory : MonoBehaviour
{
void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("게임 클리어!");
            // 예: SceneManager.LoadScene("Victory");
        }
    }
}
