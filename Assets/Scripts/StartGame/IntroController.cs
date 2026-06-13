using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroController : MonoBehaviour
{
    public TMP_Text storyText;
    public GameObject continueText;

    private bool canContinue = false;

    private string[] lines =
    {
        "Year 5139",
        "",
        "Earth's resources have nearly vanished.",
        "",
        "To preserve the last of humanity,",
        "a single survival base was established.",
        "",
        "Only a few remain inside.",
        "",
        "A newly discovered quantum technology",
        "allows communication with the past.",
        "",
        "Your mission is simple.",
        "",
        "Travel through time.",
        "Gather resources.",
        "Keep the base alive."
    };

    private void Start()
    {
        StartCoroutine(ShowStory());
    }

    IEnumerator ShowStory()
    {
        storyText.text = "";

        foreach (string line in lines)
        {
            storyText.text += line + "\n";

            yield return new WaitForSeconds(1.2f);
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