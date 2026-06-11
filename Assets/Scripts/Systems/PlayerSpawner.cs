using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    //负责运送player 的位置，但是后面还要改，先去吃个饭再说
    private void OnEnable()
    {
        //这里也是新加了一个
        Debug.Log("PlayerSpawner Enabled");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(
        Scene scene,
        LoadSceneMode mode)
    {
        //这里也加一个debug 的
        Debug.Log("Scene Loaded: " + scene.name);
        Debug.Log(
    "Target Spawn Point = " +
    SceneTransitionManager.Instance.targetSpawnPoint);
        string targetID =
            SceneTransitionManager.Instance.targetSpawnPoint;

        SpawnPoint[] points =
            FindObjectsOfType<SpawnPoint>();

        foreach (SpawnPoint point in points)
        {
            if (point.spawnID == targetID)
            {
                GameObject player =
                    GameObject.FindGameObjectWithTag("Player");

                player.transform.position =
                    point.transform.position;

                break;
            }
        }
    }
}