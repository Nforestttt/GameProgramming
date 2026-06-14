using UnityEngine;
using TMPro;
using System.Collections;

public class MissionIntro : MonoBehaviour
{
    public TMP_Text introText;

    void Start()
    {
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        yield return ShowPage(
            "Destination:\nMedieval Europe",
            1.5f
        );

        yield return ShowPage(
            "Mission Time:\n5 Minutes",
            1.5f
        );

        yield return ShowPage(
            "Collect resources\nfrom chests.",
            1.5f
        );

        yield return ShowPage(
            "Avoid the guards.",
            1.5f
        );

        yield return ShowPage(
            "Good Luck.",
            1f
        );

        yield return Countdown();

        gameObject.SetActive(false);

        MissionTimer.Instance.StartTimer();
    }

    IEnumerator ShowPage(
        string text,
        float waitTime)
    {
        introText.text = text;

        yield return new WaitForSeconds(waitTime);
    }

    IEnumerator Countdown()
    {
        introText.text = "3";
        yield return new WaitForSeconds(1f);

        introText.text = "2";
        yield return new WaitForSeconds(1f);

        introText.text = "1";
        yield return new WaitForSeconds(1f);

        introText.text = "GO!";
        yield return new WaitForSeconds(1f);
    }
}