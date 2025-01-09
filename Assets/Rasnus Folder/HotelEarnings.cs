using UnityEngine;

public class HotelEarnings : MonoBehaviour
{
    public UpgradeableItem[] HotelPieces;
    public float EarningsInterval = 5f; // Seconds

    private void Start()
    {
        InvokeRepeating(nameof(GenerateEarnings), EarningsInterval, EarningsInterval);
    }

    private void GenerateEarnings()
    {
        float totalEarnings = 0;
        foreach (var item in HotelPieces)
        {
            if(item.gameObject.activeSelf)
            {
            totalEarnings += item.GetEarnings();
            }
        }

        MoneyManager.Instance.AddMoney(totalEarnings);
        Debug.Log("Total earnings generated: " + totalEarnings);
    }
}
