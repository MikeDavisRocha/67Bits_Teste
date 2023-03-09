using UnityEngine;
using TMPro;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private Transform defeatedEnemiesTransform;
    [SerializeField] private int moneyAmountPerDefeatedEnemy = 10;
    [SerializeField] private TMP_Text moneyAmountText;

    public void GiveMoney()
    {
        int numberOfDefeatedEnemies = defeatedEnemiesTransform.childCount;
        int moneyEarned = numberOfDefeatedEnemies * moneyAmountPerDefeatedEnemy;

        // Add the money to the player's account
        PlayerStats.Instance.AddMoney(moneyEarned);

        UpdateMoneyText();

        // Remove the defeated enemies
        foreach (Transform enemy in defeatedEnemiesTransform)
        {
            Destroy(enemy.gameObject);
        }
    }

    public void UpdateMoneyText()
    {
        moneyAmountText.text = PlayerStats.Instance.GetMoney().ToString();
    }
}
