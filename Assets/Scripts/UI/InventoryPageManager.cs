using System.Collections;
using UnityEngine;

public class InventoryPageManager :
MonoBehaviour
{
    public GameObject
    inventoryPage;

    public GameObject
    profilePage;

    public GameObject
    pageFlipEffect;

    int currentPage = 0;

    void Start()
    {
        inventoryPage
        .SetActive(true);

        profilePage
        .SetActive(false);

        pageFlipEffect
        .SetActive(false);
    }

    void Update()
    {
        if (
        Input.GetKeyDown(
        KeyCode.C))
        {
            NextPage();
        }

        if (
        Input.GetKeyDown(
        KeyCode.Z))
        {
            PreviousPage();
        }
    }

    void NextPage()
    {
        Debug.Log("按下C");

        if (currentPage == 0)
        {
            StartCoroutine(
            FlipToProfile());

            currentPage = 1;
        }
    }

    void PreviousPage()
    {
        Debug.Log("按下Z");

        if (currentPage == 1)
        {
            StartCoroutine(
            FlipToInventory());

            currentPage = 0;
        }
    }

    IEnumerator FlipToProfile()
    {
        pageFlipEffect
        .SetActive(true);

        yield return
        new WaitForSeconds(
        0.3f);

        inventoryPage
        .SetActive(false);

        profilePage
        .SetActive(true);

        yield return
        new WaitForSeconds(
        5f);

        pageFlipEffect
        .SetActive(false);
    }

    IEnumerator FlipToInventory()
    {
        pageFlipEffect
        .SetActive(true);

        yield return
        new WaitForSeconds(
        0.3f);

        profilePage
        .SetActive(false);

        inventoryPage
        .SetActive(true);

        yield return
        new WaitForSeconds(
        5f);

        pageFlipEffect
        .SetActive(false);
    }
}