using UnityEngine;

public class TimerDisplayController : MonoBehaviour
{
    public DigitController minuteTen;
    public DigitController minuteOne;

    public DigitController secondTen;
    public DigitController secondOne;

    private int lastDisplayedSecond = -1;
    private void Start()
    {
        RefreshDisplay();
    }

    void Update()
    {
        if (MissionTimer.Instance == null)
            return;

        int totalSeconds =
            Mathf.CeilToInt(
                MissionTimer.Instance.GetRemainingTime()
            );

        if (totalSeconds == lastDisplayedSecond)
            return;

        lastDisplayedSecond = totalSeconds;

        RefreshDisplay();
    }

    void RefreshDisplay()
    {
        int totalSeconds =
            Mathf.CeilToInt(
                MissionTimer.Instance.GetRemainingTime()
            );

        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        minuteTen.SetDigit(minutes / 10);
        minuteOne.SetDigit(minutes % 10);

        secondTen.SetDigit(seconds / 10);
        secondOne.SetDigit(seconds % 10);
    }
}