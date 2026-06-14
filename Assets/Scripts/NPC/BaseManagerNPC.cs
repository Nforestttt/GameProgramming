using UnityEngine;

public class BaseManagerNPC : MonoBehaviour
{
    [Header("Patrol")]
    public Transform[] patrolPoints;
    public float moveSpeed = 2f;

    private int currentPointIndex = 0;

    [Header("UI")]
    public GameObject talkPrompt;

    private bool playerNearby = false;

    private Animator animator;

    private bool tutorialCompleted = false;

    private string[] introDialogue =
    {
        "Welcome to the Future Base.",

        "Human civilization is running out of resources.",

        "The supplies stored here determine whether the base survives.",

        "Your task is to gather whatever resources you can find.",

        "To begin, head through the green or red portal.",

        "You will arrive at the Future Lab.",

        "The Science Bot there will explain the time-travel missions.",

        "Return safely, survivor."
    };

    private string[] normalDialogue =
    {
        "Welcome back, survivor.",

        "Bring any resources you collect back to me.",

        "Press F to submit resources and increase the base supply.",

        "The future depends on every resource you recover."
    };

    private void Start()
    {
        animator = GetComponent<Animator>();

        if (talkPrompt != null)
        {
            talkPrompt.SetActive(false);
        }
    }

    private void Update()
    {
        // 玩家靠近时停止巡逻
        if (playerNearby)
        {
            if (animator != null)
            {
                animator.SetBool("IsMoving", false);
            }

            // E = 对话
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("player press e for base manager");
                if (DialogueManager.Instance != null)
                {
                    Debug.Log("the dialog instance not null");
                    if (!tutorialCompleted)
                    {
                        DialogueManager.Instance
                            .StartDialogue(introDialogue);

                        tutorialCompleted = true;
                    }
                    else
                    {
                        DialogueManager.Instance
                            .StartDialogue(normalDialogue);
                    }
                }

                else
                {
                    Debug.Log("the dialog instance is null");
                }
            }

            // F = 提交资源
            if (Input.GetKeyDown(KeyCode.F))
            {
                SubmitResources();
            }

            return;
        }

        Patrol();
    }

    private void Patrol()
    {
        if (patrolPoints == null ||
            patrolPoints.Length == 0)
        {
            return;
        }

        Transform target =
            patrolPoints[currentPointIndex];

        transform.position =
            Vector2.MoveTowards(
                transform.position,
                target.position,
                moveSpeed * Time.deltaTime
            );

        if (animator != null)
        {
            animator.SetBool("IsMoving", true);

            Vector2 direction =
                ((Vector2)target.position -
                 (Vector2)transform.position).normalized;

            animator.SetFloat("MoveX", direction.x);
            animator.SetFloat("MoveY", direction.y);
        }

        float distance =
            Vector2.Distance(
                transform.position,
                target.position
            );

        if (distance < 0.1f)
        {
            currentPointIndex++;

            if (currentPointIndex >= patrolPoints.Length)
            {
                currentPointIndex = 0;
            }
        }
    }

    private void SubmitResources()
    {
        int totalSupply = 0;

        foreach (var item in Inventory.Instance.items)
        {
            int value =
                SupplyManager.Instance
                .GetItemValue(item.Key);

            totalSupply +=
                value * item.Value;
        }

        SupplyManager.Instance.AddSupply(totalSupply);

        Debug.Log(
            "Submitted +" +
            totalSupply);

        Inventory.Instance.ClearInventory();

        if (DialogueManager.Instance != null)
        {
            string[] submitDialogue =
            {
                "Resources received.",

                "Base supply has been updated.",

                "Thank you for supporting the future."
            };

            DialogueManager.Instance
                .StartDialogue(submitDialogue);
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