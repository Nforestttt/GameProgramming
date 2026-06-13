using UnityEngine;
using System.Collections;

public class GuardPatrol : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    public float waitTime = 1f;

    [Header("Detection Settings")]
    public Transform player;
    public float detectionRange = 3f;
    public float chaseSpeed = 3.5f;

    [Header("Chase Limit")]
    public float maxChaseDistance = 6f;

    private int currentWaypoint = 0;

    private bool isWaiting = false;
    private bool isChasing = false;
    private bool isReturning = false;

    private float catchingDistance = 0.5f;

    private Animator animator;
    private Vector2 lastMoveDirection = Vector2.down;

    private bool hasCaughtPlayer = false;

    private Vector3 guardStartPosition;

    void Start()
    {
        animator = GetComponent<Animator>();

        player =
            GameObject.FindGameObjectWithTag("Player")
            ?.transform;

        guardStartPosition = transform.position;
    }

    void Update()
    {
        if (player == null)
        {
            player =
                GameObject.FindGameObjectWithTag("Player")
                ?.transform;
        }

        DetectPlayer();

        if (isChasing)
        {
            ChasePlayer();
            return;
        }

        if (isReturning)
        {
            ReturnToPatrol();
            return;
        }

        if (waypoints.Length == 0 || isWaiting)
            return;

        MoveToWaypoint();
    }

    void DetectPlayer()
    {
        if (player == null)
            return;

        if (isReturning)
            return;

        float distance = Vector2.Distance(
            transform.position,
            player.position
        );

        if (!isChasing && distance <= detectionRange)
        {
            isChasing = true;
        }
    }

    void ChasePlayer()
    {
        Vector2 direction =
            ((Vector2)player.position -
             (Vector2)transform.position).normalized;

        transform.position =
            Vector2.MoveTowards(
                transform.position,
                player.position,
                chaseSpeed * Time.deltaTime
            );

        animator.SetBool("IsMoving", true);

        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);

        lastMoveDirection = direction;

        float distanceToPlayer =
            Vector2.Distance(
                transform.position,
                player.position
            );

        //这里和那个game manager 一样，也需要加一个hide 让has caught player 变成初始状态变成false
        if (distanceToPlayer <= catchingDistance &&
            !hasCaughtPlayer)
        {
            hasCaughtPlayer = true;

            GameManager.Instance.playerCaught();
        }

        float distanceFromPost =
            Vector2.Distance(
                transform.position,
                guardStartPosition
            );

        if (distanceFromPost > maxChaseDistance)
        {
            isChasing = false;
            isReturning = true;
        }
    }

    //这个reset 很关键，可以写在报告里
    public void ResetGuard()
    {
        hasCaughtPlayer = false;

        isChasing = false;

        isReturning = false;

        isWaiting = false;

        transform.position = guardStartPosition;

        animator.SetBool("IsMoving", false);
    }

    void ReturnToPatrol()
    {
        Vector2 direction =
            ((Vector2)guardStartPosition -
             (Vector2)transform.position).normalized;

        transform.position =
            Vector2.MoveTowards(
                transform.position,
                guardStartPosition,
                moveSpeed * Time.deltaTime
            );

        animator.SetBool("IsMoving", true);

        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);

        float distance =
            Vector2.Distance(
                transform.position,
                guardStartPosition
            );

        if (distance < 0.1f)
        {
            isReturning = false;

            currentWaypoint = FindNearestWaypoint();
        }
    }

    int FindNearestWaypoint()
    {
        int nearestIndex = 0;

        float nearestDistance =
            Mathf.Infinity;

        for (int i = 0; i < waypoints.Length; i++)
        {
            float distance =
                Vector2.Distance(
                    transform.position,
                    waypoints[i].position
                );

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestIndex = i;
            }
        }

        return nearestIndex;
    }

    void MoveToWaypoint()
    {
        Transform target =
            waypoints[currentWaypoint];

        Vector2 direction =
            ((Vector2)target.position -
             (Vector2)transform.position).normalized;

        transform.position =
            Vector2.MoveTowards(
                transform.position,
                target.position,
                moveSpeed * Time.deltaTime
            );

        float distance =
            Vector2.Distance(
                transform.position,
                target.position
            );

        if (distance > 0.05f)
        {
            animator.SetBool("IsMoving", true);

            animator.SetFloat("MoveX", direction.x);
            animator.SetFloat("MoveY", direction.y);

            lastMoveDirection = direction;
        }
        else
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;

        animator.SetBool("IsMoving", false);

        animator.SetFloat(
            "MoveX",
            lastMoveDirection.x
        );

        animator.SetFloat(
            "MoveY",
            lastMoveDirection.y
        );

        yield return new WaitForSeconds(waitTime);

        currentWaypoint++;

        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }

        isWaiting = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            transform.position,
            detectionRange
        );

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(
            Application.isPlaying
                ? guardStartPosition
                : transform.position,
            maxChaseDistance
        );
    }
}