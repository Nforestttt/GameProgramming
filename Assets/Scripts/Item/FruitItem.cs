using UnityEngine;

public class FruitItem :
MonoBehaviour,
IInteractable
{
    public string itemName =
    "Apple";
    public AudioClip pickupSound;
    public void Interact(
    GameObject interactor)
    {
        Inventory.Instance
        .Add(itemName);

        AudioManager.Instance.PlaySFX(pickupSound);

        Destroy(gameObject);
    }
}