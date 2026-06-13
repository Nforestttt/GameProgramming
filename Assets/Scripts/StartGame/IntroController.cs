using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroController : MonoBehaviour
{
    public TMP_Text storyText;
    public GameObject continueText;

    private bool canContinue = false;

    private string[] pages =
    {
        "Year 2189",

        "Earth's resources have nearly vanished.",

        "Humanity survives inside a single base.",

        "A quantum technology connects us to the past.",

        "Gather resources. Protect the future."
    };

    private void Start()
    {
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        Color color = storyText.color;

        foreach (string page in pages)
        {
            storyText.text = page;

            //
            // Fade In
            //
            for (float a = 0; a <= 1; a += Time.deltaTime)
            {
                color.a = a;
                storyText.color = color;

                yield return null;
            }

            //
            // Hold
            //
            yield return new WaitForSeconds(2f);

            //
            // Fade Out
            //
            for (float a = 1; a >= 0; a -= Time.deltaTime)
            {
                color.a = a;
                storyText.color = color;

                yield return null;
            }

            yield return new WaitForSeconds(0.3f);
        }

        continueText.SetActive(true);

        canContinue = true;
    }

    private void Update()
    {
        if (!canContinue)
            return;

        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("FutureBase");
        }
    }
}