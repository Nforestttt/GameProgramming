using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("StoryIntroduction");
    }

    public void StartInstruction()
    {
        SceneManager.LoadScene("Instruction");
    }

    public void BackFromIntruction()
    {
        SceneManager.LoadScene("BeginGame");
    }
}