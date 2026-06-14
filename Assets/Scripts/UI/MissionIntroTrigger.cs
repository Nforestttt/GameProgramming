using UnityEngine;

public class MissionIntroTrigger : MonoBehaviour
{
    public GameObject missionIntroPanel;

    void Start()
    {
        missionIntroPanel.SetActive(true);
        MissionTimer.Instance.StartTimer();
        Debug.Log("计时开始");
    }
}