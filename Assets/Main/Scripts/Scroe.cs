using UnityEngine;
using UnityEngine.UI;

public class Scroe : MonoBehaviour
{
public static int score = 0;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    
    void Update()
    {
        text.text = "Kill: " + score;
    }
}
