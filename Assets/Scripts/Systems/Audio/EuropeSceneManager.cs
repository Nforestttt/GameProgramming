using UnityEngine;

public class EuropeSceneManager : MonoBehaviour
{
    public AudioClip medievalBGM;

    void Start()
    {
        AudioManager.Instance.PlayMusic(medievalBGM);
    }
}