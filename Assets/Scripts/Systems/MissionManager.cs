using UnityEngine;

public class MissionManager :
MonoBehaviour
{
    public static
    MissionManager
    Instance;

    void Awake()
    {
        Instance = this;
    }

    public void StartMission()
    {

    }

    public void ReturnToBase()
    {

    }
}