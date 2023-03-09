using System.Collections;
using UnityEngine;

public class CharacterPunch : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();            

            if (enemy.GetNumberOfDefeatedEnemies() < PlayerStats.Instance.GetMaxStackLevel())
            {
                // Play the punch animation
                animator.SetLayerWeight(1, 1);
                animator.SetTrigger("Punch");

                // Deactivate Enemy Animator
                Animator enemyAnimator = enemy.GetComponent<Animator>();
            
                if (enemyAnimator != null)
                {
                    enemyAnimator.enabled = false;
                }

                // Stack defeated enemy on player back
                enemy.StackEnemy();
            }

        }
        else if (other.CompareTag("MoneyController"))
        {
            MoneyController moneyController = other.GetComponent<MoneyController>();

            if (moneyController != null)
            {
                moneyController.GiveMoney();
            }
        }
        else if (other.CompareTag("LevelUpController"))
        {
            LevelUpController levelUpController = other.GetComponent<LevelUpController>();

            if (levelUpController != null)
            {
                SkinnedMeshRenderer skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
                levelUpController.LevelUp(skinnedMeshRenderer);
            }
        }
    }
}