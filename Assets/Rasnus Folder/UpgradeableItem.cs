using UnityEngine;

public class UpgradeableItem : MonoBehaviour
{
    public string ItemName;
    public int UpgradeLevel { get; private set; } = 0;
    public float BaseUpgradeCost = 100f;
    public float CostMultiplier = 1.5f;

    public float UpgradeEffectMultiplier = 1.2f;
    public float BaseEarning = 10f;

    public void Upgrade()
    {
        float upgradeCost = GetUpgradeCost();
        if (MoneyManager.Instance.SpendMoney(upgradeCost))
        {
            UpgradeLevel++;
            Debug.Log($"{ItemName} upgraded to level {UpgradeLevel}!");
        }
    }

    public float GetUpgradeCost()
    {
        return BaseUpgradeCost * Mathf.Pow(CostMultiplier, UpgradeLevel);
    }

    public float GetEarnings()
    {
        return BaseEarning * Mathf.Pow(UpgradeEffectMultiplier, UpgradeLevel);
    }
}
