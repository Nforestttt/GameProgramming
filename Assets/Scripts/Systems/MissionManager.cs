using UnityEngine;

public class MissionManager :
MonoBehaviour
{
    public static
    MissionManager
    Instance;

    //这里的awake 改成这样就不会重复生成很多instance 出来不停覆盖了
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

    public void StartMission()
    {

    }

    public void ReturnToBase()
    {

    }
}