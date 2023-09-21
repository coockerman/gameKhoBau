using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;

    CharacterMove characterMove;
    Vector2 movement;
    private void Awake()
    {
        characterMove = GetComponent<CharacterMove>();
    }
    void Update()
    {
        if (characterMove.MoveDir != Vector3.zero)
        {
            animator.SetFloat("Horizontal", characterMove.MoveDir.x);
            animator.SetFloat("Vertical", characterMove.MoveDir.y);
            return;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (characterMove.MoveDir != Vector3.zero)
        {
            animator.SetFloat("LastHorizontal", characterMove.MoveDir.x);
            animator.SetFloat("LastVertical", characterMove.MoveDir.y);
            return;
        }
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
        }
    }
}
