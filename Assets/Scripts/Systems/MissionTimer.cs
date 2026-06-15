using UnityEngine;

public class MissionTimer : MonoBehaviour
{
    public static MissionTimer Instance;

    public float maxTime = 30f;

    private float currentTime;

    private bool running;

    [Header("Audio")]
    public AudioClip missionCompleteSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentTime = maxTime;
        Debug.Log("start mission timer: 30 second");
    }

    void Update()
    {
        if (!running)
            return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            running = false;

            MissionFailed();
        }
    }

    public void StartTimer()
    {
        currentTime = maxTime;
        running = true;
    }

    public void StopTimer()
    {
        running = false;
    }

    public float GetRemainingTime()
    {
        return currentTime;
    }

    void MissionFailed()
    {
        Debug.Log("Time Up!");

        SceneTransitionManager.Instance.targetSpawnPoint =
            "Portal-from-Medieval";

        AudioManager.Instance.PlaySFX(missionCompleteSound);


        SceneTransitionManager.Instance.LoadLocation(
            GameLocation.FutureLab);
    }
}