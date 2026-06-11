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

    private int currentWaypoint = 0;
    private bool isWaiting = false;
    private bool isChasing = false;

    private float chasingDistance = 0.5f;

    private Animator animator;
    private Vector2 lastMoveDirection = Vector2.down;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        DetectPlayer();

        if (isChasing)
        {
            ChasePlayer();
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

        float distance = Vector2.Distance(
            transform.position,
            player.position
        );

        if (distance <= detectionRange)
        {
            isChasing = true;
        }
    }

    void ChasePlayer()
    {
        Vector2 direction =
            ((Vector2)player.position - (Vector2)transform.position).normalized;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            chaseSpeed * Time.deltaTime
        );

        animator.SetBool("IsMoving", true);

        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);

        lastMoveDirection = direction;

        float distance = Vector2.Distance(transform.position, player.position);

        if(distance<=chasingDistance)
        {
            //这里后面再加内容
            GameManager.Instance.playerCaught();
        }
    }

    void MoveToWaypoint()
    {
        Transform target = waypoints[currentWaypoint];

        Vector2 direction =
            ((Vector2)target.position - (Vector2)transform.position).normalized;

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            moveSpeed * Time.deltaTime
        );

        float distance = Vector2.Distance(
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

        animator.SetFloat("MoveX", lastMoveDirection.x);
        animator.SetFloat("MoveY", lastMoveDirection.y);

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
    }
}