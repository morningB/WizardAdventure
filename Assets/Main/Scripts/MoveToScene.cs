using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToScene : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("BigIsland");
    }
    public void GoToStart()
    {
        SceneManager.LoadScene("Start");
    }
}
