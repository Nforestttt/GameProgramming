using UnityEngine;
using System.Collections;

public class GuardPatrol : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform[] waypoints;

    public float moveSpeed = 2f;

    public float waitTime = 1f;

    private int currentWaypoint = 0;

    private bool isWaiting = false;

    private Animator animator;

    private Vector2 lastMoveDirection = Vector2.down;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (waypoints.Length == 0 || isWaiting)
            return;

        MoveToWaypoint();
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

        float distance =
            Vector2.Distance(transform.position, target.position);

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
}