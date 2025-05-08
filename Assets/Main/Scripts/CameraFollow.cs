using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    public Vector3 offset;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        offset = new Vector3(11.36f,15.3f,-11.2f);
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position = Vector3.Lerp(transform.position,
        player.position + offset,Time.deltaTime * 10);
        // transform.position = player.position + new Vector3(0,6,-8);
    }
}
