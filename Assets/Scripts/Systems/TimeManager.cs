using UnityEngine;

public class TimeManager :
MonoBehaviour
{
    public static
    TimeManager
    Instance;

    public GameLocation
    currentLocation =
    GameLocation.FutureBase;

    //和mission manager 的原理是一样的
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

    public void ChangeLocation(
    GameLocation location1)
    {
        currentLocation = location1;
    }
}