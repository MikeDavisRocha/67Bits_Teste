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
}