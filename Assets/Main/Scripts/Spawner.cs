using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float time;
    public Transform[] point;

    public int max;
    public int count;

    void Start()
    {
        InvokeRepeating("Create", time, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Create()
    {
        if(count >= max)
        {
            return;
        }

        count++;
        int i = Random.Range(0, point.Length);
        Instantiate(prefab, point[i].position, point[i].rotation);
    }
}
