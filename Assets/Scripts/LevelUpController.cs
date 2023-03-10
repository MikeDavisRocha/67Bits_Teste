using UnityEngine;
using TMPro;

public class LevelUpController : MonoBehaviour
{
    [SerializeField] private TMP_Text levelAmountText;
    [SerializeField] private Color characterColor;
    [SerializeField] private int requiredMoneyPerLevel;
    [SerializeField] private MoneyController moneyController;
    [SerializeField] private int stackLevelAmount;
    private bool levelLocked = true;

    public void LevelUp(SkinnedMeshRenderer player)
    {
        // Check if the player has enough money to level up
        int playerMoney = PlayerStats.Instance.GetMoney();

        if (!levelLocked)
        {
            player.materials[0].color = characterColor;
            return;
        }

        if (playerMoney >= requiredMoneyPerLevel)
        {
            // Deduct the required money from the player's account
            PlayerStats.Instance.DeductMoney(requiredMoneyPerLevel);            

            // Increase the stack level
            PlayerStats.Instance.IncreaseMaxStackLevel(stackLevelAmount);

            // Update the level amount text
            UpdateLevelText();

            moneyController.UpdateMoneyText();

            player.materials[0].color = characterColor;

            levelLocked = false;
        }
    }

    private void UpdateLevelText()
    {
        int playerLevel = PlayerStats.Instance.GetMaxStackLevel();
        levelAmountText.text = playerLevel.ToString();
    }
}
