using TMPro;
using UnityEngine;

public class SupplyUI : MonoBehaviour
{
    public TMP_Text supplyText;

    void Update()
    {
        supplyText.text =
            $"Base Supply: " +
            $"{SupplyManager.Instance.currentSupply}" +
            $" / " +
            $"{SupplyManager.Instance.targetSupply}";
    }
}