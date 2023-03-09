using EasyJoystick;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 5f;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();        
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 inputVector = new Vector2(joystick.Horizontal(), joystick.Vertical());
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDirection != Vector3.zero)
        {
            // Rotate towards the move direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            // Move the character
            transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

            // Set the animation state to "Run"
            animator.SetBool("IsWalking", true);
        }
        else
        {
            // Set the animation state to "Idle"
            animator.SetBool("IsWalking", false);
        }
    }
}
