using UnityEngine;

// Class that controll the basic movement of player, including top, down, right and left
public class PlayerMovement : MonoBehaviour
{
    // parameter that controll the move speed of player
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    public AudioClip footstepSound;

    private float stepTimer;
    public float stepInterval = 0.4f;

    /// <summary>
    /// Description: 
    /// this update function is used to update the movement of users, including two axies, horizontal and vertical
    /// In each frame this function will called by game system and the movement will update
    /// Inputs:
    /// None
    /// Outputs:
    /// None
    /// </summary>

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);

            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0)
            {
                AudioManager.Instance.PlaySFX(
                    footstepSound);

                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0;
        }
    }

    /// <summary>
    /// Descriptions:
    ///This function is used to hold a fixed movement of the player,
    ///called automatically for every frame
    /// Inputs:
    /// None
    /// Outputs:
    /// None
    /// </summary>
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}