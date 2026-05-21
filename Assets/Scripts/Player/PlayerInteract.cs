using UnityEngine;

public class PlayerInteract :
MonoBehaviour
{
    public float interactRadius = 1f;

    public LayerMask interactLayer;

    void Update()
    {
        if (Input.GetKeyDown(
        KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Collider2D[] hits =
        Physics2D
        .OverlapCircleAll(
        transform.position,
        interactRadius,
        interactLayer);

        foreach (
        Collider2D hit
        in hits)
        {
            IInteractable obj =
            hit.GetComponent
            <IInteractable>();

            if (obj != null)
            {
                obj.Interact(
                gameObject);

                break;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color =
        Color.yellow;

        Gizmos.DrawWireSphere(
        transform.position,
        interactRadius);
    }
}