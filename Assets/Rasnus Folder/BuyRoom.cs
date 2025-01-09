using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyRoom : MonoBehaviour
{
    [Header("Room Details")]
    public GameObject roomPrefab;  // The room prefab to activate when purchased
    public float RoomCost = 500f; // Base cost of the room

    [Header("UI References")]
    public TextMeshProUGUI RoomCostText;  // UI element to show the room cost
    public Button BuyRoomButton;  // Button that triggers the purchase
    

    private void Start()
    {
        // Display the room cost when the game starts
        UpdateRoomCostUI();
        
        // Add listener to the BuyRoomButton
        BuyRoomButton.onClick.AddListener(HandleRoomPurchase);
    }

    // This method is triggered when the player clicks the buy room button
    private void HandleRoomPurchase()
    {
        // Check if the player has enough money
        if (MoneyManager.Instance.SpendMoney(RoomCost))
        {
            ActivateRoom();  // If the player has enough money, activate the room
        }
        else
        {
            Debug.Log("Not enough money to buy the room!");
        }
    }

    // Get the room cost (can include dynamic pricing logic if necessary)

    // Activate the room prefab
    private void ActivateRoom()
    {
        if (roomPrefab != null)
        {
            roomPrefab.SetActive(true);  // Activate the room prefab
            Debug.Log("Room purchased and activated!");
            Destroy(gameObject);
        }
    }

    // Update the UI to show the current room cost
    private void UpdateRoomCostUI()
    {
        if (RoomCostText != null)
        {
            RoomCostText.text = $"Room Cost: €{RoomCost:F2}";
        }
    }
}
