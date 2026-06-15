using UnityEngine;

public class FutureMusicTrigger : MonoBehaviour
{
    public AudioClip futureBGM;

    void Start()
    {
        AudioManager.Instance.PlayMusic(futureBGM);
    }
}