// MinimapFollow.cs
using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        // 플레이어 위치만 따라가고, 회전은 고정
        Vector3 newPos = player.position;
        newPos.y += 20f; // 높이
        transform.position = newPos;

        // 미니맵이 항상 위를 바라보게, X 90도만 유지(Y는 0!)
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}
