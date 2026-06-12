using UnityEngine;

public class GameManager :
MonoBehaviour
{
    public static
    GameManager Instance;

    void Awake()
    {
        if (
        Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void playerCaught()
    {
        MissionTimer.Instance.StopTimer();
        SceneTransitionManager.Instance.targetSpawnPoint = "Portal-from-Medieval";

        SceneTransitionManager.Instance.LoadLocation(GameLocation.FutureLab);
    }
}