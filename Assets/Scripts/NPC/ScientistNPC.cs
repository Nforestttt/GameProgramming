using UnityEngine;

public class ScientistNPC : MonoBehaviour
{
    [Header("Patrol")]
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 2f;

    [Header("UI")]
    public GameObject talkPrompt;

    private Transform targetPoint;

    private bool playerNearby = false;

    private string[] dialogue =
    {
        "Quantum channel is stable.",

        "We need more resources to keep the base alive.",

        "Travel to the past and gather supplies.",

        "Please go to the blue door. "
    };

    private Animator animator;

    private Vector2 lastMoveDirection = Vector2.down;


    [Header("Voice")]
    public AudioClip botVoice;

    void Start()
    {
        targetPoint = pointB;

        animator = GetComponent<Animator>();

        if (talkPrompt != null)
        {
            talkPrompt.SetActive(false);
        }
    }

    void Update()
    {
        //
        // 对话期间完全不动
        //
        if (DialogueManager.Instance != null &&
            DialogueManager.Instance.IsTalking())
        {
            animator.SetBool("IsMoving", false);
            return;
        }

        //
        // 玩家靠近时停止巡逻
        //
        if (playerNearby)
        {
            animator.SetBool("IsMoving", false);

            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogueManager.Instance.StartDialogue(dialogue,botVoice);
            }

            return;
        }

        Patrol();
    }

    void Patrol()
    {
        transform.position =
            Vector2.MoveTowards(
                transform.position,
                targetPoint.position,
                moveSpeed * Time.deltaTime
            );

        Vector2 direction =
            ((Vector2)targetPoint.position -
             (Vector2)transform.position).normalized;

        animator.SetBool("IsMoving", true);

        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);

        lastMoveDirection = direction;

        float distance =
            Vector2.Distance(
                transform.position,
                targetPoint.position
            );

        if (distance < 0.1f)
        {
            targetPoint =
                targetPoint == pointA
                ? pointB
                : pointA;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerNearby = true;

        if (talkPrompt != null)
        {
            talkPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerNearby = false;

        if (talkPrompt != null)
        {
            talkPrompt.SetActive(false);
        }
    }
}