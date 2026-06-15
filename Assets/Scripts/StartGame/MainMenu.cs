using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip menuBGM;
    public AudioClip buttonClick;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(menuBGM);
    }

    public void StartGame()
    {
        StartCoroutine(LoadSceneWithSound("StoryIntroduction"));
    }

    public void StartInstruction()
    {
        StartCoroutine(LoadSceneWithSound("Instruction"));
    }

    public void BackFromIntruction()
    {
        StartCoroutine(LoadSceneWithSound("BeginGame"));
    }

    private IEnumerator LoadSceneWithSound(string sceneName)
    {
        AudioManager.Instance.PlaySFX(buttonClick);

        yield return new WaitForSeconds(0.15f);

        SceneManager.LoadScene(sceneName);
    }
}