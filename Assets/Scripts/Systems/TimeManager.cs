using UnityEngine;

public class TimeManager :
MonoBehaviour
{
    public static
    TimeManager
    Instance;

    public Era
    currentEra =
    Era.Future;

    void Awake()
    {
        Instance = this;
    }

    public void ChangeEra(
    Era era)
    {
        currentEra = era;
    }
}