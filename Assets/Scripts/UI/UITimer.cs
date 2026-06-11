using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    void Update()
    {
        if (MissionTimer.Instance == null)
            return;

        float time =
            MissionTimer.Instance.GetRemainingTime();

        int minutes =
            Mathf.FloorToInt(time / 60);

        int seconds =
            Mathf.FloorToInt(time % 60);

        timerText.text =
            string.Format(
                "{0:00}:{1:00}",
                minutes,
                seconds
            );
    }
}