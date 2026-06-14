using UnityEngine;

public class SupplyManager : MonoBehaviour
{
    public static SupplyManager Instance;

    public int currentSupply = 0;

    public int targetSupply = 100;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetItemValue(string itemName)
    {
        Debug.Log(
       "Checking item: " +
       itemName);

        switch (itemName)
        {
            // 普通水果
            case "Apple":
            case "Banana":
            case "Pear":
                return 1;

            // 中等水果
            case "Orange":
            case "Peach":
            case "Grape":
            case "Kiwi":
                return 2;

            // 高级水果
            case "Cherry":
            case "Pineapple":
            case "Strawberry":
            case "Watermelon":
            case "Lemon":
                return 3;

            default:
                Debug.LogWarning(
                    "Unknown Item: " +
                    itemName);

                return 0;
        }
    }

    public void AddSupply(int amount)
    {
        currentSupply += amount;

        Debug.Log(
            "Supply +" +
            amount +
            " | Current Supply: " +
            currentSupply);

        CheckVictory();
    }

    private void CheckVictory()
    {
        if (currentSupply >= targetSupply)
        {
            Debug.Log(
                "MISSION COMPLETE");
        }
    }
}