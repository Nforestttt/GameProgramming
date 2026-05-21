using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<string> items =
        new List<string>();

    void Awake()
    {
        Instance = this;
    }
    
    public void Add(string item)
    {
        items.Add(item);

        Debug.Log(
        "Picked up: " + item);
    }
}