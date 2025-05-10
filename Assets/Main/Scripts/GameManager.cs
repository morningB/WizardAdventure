using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int keysCollected = 0;
    public int totalKeysRequired = 2;

    public GameObject targetZone; // 최종 지역 오브젝트
    public Text targetZoneText;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void AddKey()
    {
        keysCollected++;
        Debug.Log("Key Collected: " + keysCollected);

        if (keysCollected >= totalKeysRequired)
        {
            ActivateTargetZone();
        }
    }

    void ActivateTargetZone()
{
    if (targetZone != null)
    {
        targetZone.SetActive(true);
        Debug.Log("최종 지역이 활성화됨!");
        StartCoroutine(ShowTargetZoneText());
    }
}

    IEnumerator ShowTargetZoneText()
    {
        targetZoneText.gameObject.SetActive(true);
        targetZoneText.text = "탈출 포탈이 산 정상에 생성되었습니다!!";
        yield return new WaitForSeconds(3f);
        targetZoneText.gameObject.SetActive(false);
    }
}
