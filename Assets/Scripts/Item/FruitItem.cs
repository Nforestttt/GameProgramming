using UnityEngine;

public class FruitItem :
MonoBehaviour,
IInteractable
{
    public string itemName =
    "Apple";

    public void Interact(
    GameObject interactor)
    {
        Inventory.Instance
        .Add(itemName);

        Destroy(gameObject);
    }
}