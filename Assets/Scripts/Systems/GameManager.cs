using UnityEngine;
using System.Collections;

public class GameManager :
MonoBehaviour
{
    public static
    GameManager Instance;
    private bool missionFailing = false;

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
        //这里建了一个协程，而非是一个普通的函数内容
        if (missionFailing)
            return;
        missionFailing = true;
        StartCoroutine(PlayerCaughtRoutine());
    }

    private IEnumerator PlayerCaughtRoutine()
    {
        Debug.Log("player caught! 玩家被抓，开始接下来的步骤");
        MissionTimer.Instance.StopTimer();

        Debug.Log("停止timer 完毕");
        MissionFailUI.Instance.Show();
        Debug.Log("显示mission fail 完毕");
        yield return new WaitForSeconds(3f);
        Debug.Log("等待两秒结束");

        MissionFailUI.Instance.Hide();

        GuardPatrol[] guards =
       FindObjectsOfType<GuardPatrol>();

        foreach (GuardPatrol guard in guards)
        {
            guard.ResetGuard();
        }

        missionFailing = false;

        SceneTransitionManager.Instance.targetSpawnPoint =
            "Portal-from-Medieval";

        SceneTransitionManager.Instance.LoadLocation(
            GameLocation.FutureLab
        );

    }
}