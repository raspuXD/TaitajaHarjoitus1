using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bills : MonoBehaviour
{
    [Header("Bill Settings")]
    public float billAmount = 10f; // Amount deducted each interval
    public float billInterval = 1.3f * 60f; // Time in seconds (1.3 minutes)

    private void Start()
    {
        // Start the bill deduction process when the game starts
        StartCoroutine(DeductBills());
    }

    private IEnumerator DeductBills()
    {
        while (true)
        {
            yield return new WaitForSeconds(billInterval); // Wait for the interval

            // Deduct the bill first before adding earnings
            MoneyManager.Instance.PayBills(billAmount);  // Correctly call the PayBills method on the singleton instance

            Debug.Log($"Bill deducted: {billAmount}. Remaining: {MoneyManager.Instance.Money}");

            if (MoneyManager.Instance.Money <= 0)
            {
                // If not enough money, trigger the loss condition
                OnPlayerLose();
                break; // Exit the loop, stop deducting bills
            }
        }
    }

    private void OnPlayerLose()
    {
        // Trigger a loss condition, for example by showing a "You Lose" message or restarting the game
        Debug.Log("Player has lost due to insufficient funds!");
        SceneManager.LoadScene("mainmenu");
        // Example: GameManager.Instance.GameOver();
    }
}
