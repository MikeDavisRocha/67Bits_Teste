using System.Collections;
using UnityEngine;

public class CharacterPunch : MonoBehaviour
{
    [SerializeField] private float punchForce = 10f;
    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Apply force to the enemy
            Vector3 punchDirection = (other.transform.position - transform.position).normalized;
            other.GetComponent<Rigidbody>().AddForce(punchDirection * punchForce, ForceMode.Impulse);

            // Play the punch animation
            animator.SetLayerWeight(1, 1);

            // Start the punch animation
            animator.SetTrigger("Punch");

            // Deactivate Enemy Animator
            other.GetComponent<Animator>().enabled = false;
        }
    }
}
