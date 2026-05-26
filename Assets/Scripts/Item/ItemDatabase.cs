using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase :
MonoBehaviour
{
    public static ItemDatabase Instance;

    public List<ItemData>
    items =
    new();

    Dictionary<string,
    Sprite>
    iconMap =
    new();

    void Awake()
    {
        Instance = this;

        foreach (
        ItemData item
        in items)
        {
            iconMap[
            item.itemName]
            = item.icon;
        }
    }

    public Sprite GetIcon(
    string itemName)
    {
        if (
        iconMap.ContainsKey(
        itemName))
        {
            Debug.Log(
            "’“µΩ£∫" +
            itemName);

            return iconMap[
            itemName];
        }

        Debug.Log(
        "√ª’“µΩ£∫" +
        itemName);

        return null;
    }
}