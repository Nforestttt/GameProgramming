using System.Collections;
using UnityEngine;

public class InventoryToggle :
MonoBehaviour
{
    public GameObject
    inventoryRoot;

    Animator animator;

    bool opened =
    false;

    void Start()
    {
        animator =
        inventoryRoot
        .transform
        .Find(
        "WindowContainer")
        .GetComponent
        <Animator>();

        inventoryRoot
        .SetActive(false);
    }

    void Update()
    {
        if (
        Input.GetKeyDown(
        KeyCode.Tab))
        {
            if (!opened)
            {
                OpenInventory();
            }
            else
            {
                StartCoroutine(
                CloseInventory());
            }
        }
    }

    void OpenInventory()
    {
        opened = true;

        inventoryRoot
        .SetActive(true);

        animator.Play(
        "InventoryOpen",
        0,
        0f);
    }

    IEnumerator CloseInventory()
    {
        opened = false;

        animator.Play(
        "InventoryClose",
        0,
        0f);

        yield return
        new WaitForSeconds(
        0.2f);

        inventoryRoot
        .SetActive(false);
    }

}