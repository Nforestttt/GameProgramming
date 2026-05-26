using System.Collections.Generic;
using UnityEngine;

public class Inventory :
MonoBehaviour
{
    public static Inventory Instance;

    public Dictionary<string, int>
    items =
    new();

    public InventoryUI inventoryUI;

    void Awake()
    {
        Instance = this;
    }

    public void Add(
    string item)
    {
        if (
        items.ContainsKey(item))
        {
            items[item]++;
        }
        else
        {
            items[item] = 1;
        }

        inventoryUI.Refresh();

        Debug.Log(
        item +
        " x" +
        items[item]);
    }
}