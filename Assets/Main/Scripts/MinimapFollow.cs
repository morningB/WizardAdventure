// MinimapFollow.cs
using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        // �÷��̾� ��ġ�� ���󰡰�, ȸ���� ����
        Vector3 newPos = player.position;
        newPos.y += 20f; // ����
        transform.position = newPos;

        // �̴ϸ��� �׻� ���� �ٶ󺸰�, X 90���� ����(Y�� 0!)
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}
