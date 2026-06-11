using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Follow Settings")]
    public float smoothing = 5f;

    private Transform target;

    private Vector3 offset = new Vector3(0f, 0f, -10f);

    void Start()
    {
        FindPlayer();
        SnapToTarget();
    }

    void LateUpdate()
    {
        // 防止场景切换时找不到Player
        if (target == null)
        {
            FindPlayer();
            return;
        }

        Vector3 targetPosition =
            target.position + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothing * Time.deltaTime
        );
    }

    void FindPlayer()
    {
        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            target = player.transform;
        }
    }

    public void SnapToTarget()
    {
        if (target == null)
            return;

        transform.position =
            target.position + offset;
    }
}