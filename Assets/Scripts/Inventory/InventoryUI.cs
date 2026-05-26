using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI :
MonoBehaviour
{
    public Transform grid;

    public GameObject
    slotPrefab;

    void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        foreach (
        Transform child
        in grid)
        {
            Destroy(
            child.gameObject);
        }

        foreach (
        var item
        in Inventory
        .Instance
        .items)
        {
            GameObject slot =
            Instantiate(
            slotPrefab,
            grid);

            slot.transform
            .Find(
            "CountText")
            .GetComponent
            <TextMeshProUGUI>()
            .text =
            "x" +
            item.Value;

            slot.transform
            .Find(
            "ItemIcon")
            .GetComponent
            <Image>()
            .sprite =
            ItemDatabase
            .Instance
            .GetIcon(
            item.Key);
        }
    }
}