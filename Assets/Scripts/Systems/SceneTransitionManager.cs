using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{

    //负责加载场景，获取需要去的场景，从portal 那里传过来是这个意思吧
    public static SceneTransitionManager Instance;
    public string targetSpawnPoint;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject spawn = GameObject.Find(targetSpawnPoint);

        if (spawn != null && PlayerSingleton.Instance != null)
        {
            PlayerSingleton.Instance.transform.position = spawn.transform.position;
        }
    }


    public void LoadLocation(
        GameLocation location)
    {
        TimeManager.Instance.ChangeLocation(location);
        //这里的mission timer 计时器放在这里，只要开始场景切换就开始计时，但是后面可能需要包装

        switch (location)
        {
            case GameLocation.FutureBase:
                SceneManager.LoadScene("FutureBase");
                break;

            case GameLocation.FutureLab:
                MissionTimer.Instance.StopTimer();
                Debug.Log("计时停止");
                SceneManager.LoadScene("FutureLab");
                break;

            case GameLocation.Medieval:
                SceneManager.LoadScene("EuropeScene");
                break;
        }
    }
}