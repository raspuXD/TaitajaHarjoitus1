using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    public float Money { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddMoney(float amount)
    {
        Money += amount;
        Debug.Log("Money added: " + amount + ". Total: " + Money);
    }

    public bool SpendMoney(float amount)
    {
        if (Money >= amount)
        {
            Money -= amount;
            Debug.Log("Money spent: " + amount + ". Remaining: " + Money);
            return true;
        }
        else
        {
            Debug.Log("Not enough money!");
            return false;
        }
    }
}
