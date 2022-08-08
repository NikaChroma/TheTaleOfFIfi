using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private float JumpForce;
    [SerializeField] private float JumpOffset;
    [SerializeField] private AnimationCurve curve;
    private bool isGrounded = false;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Animator foxAnim;
    [SerializeField] private Transform GroundColliderTransform;
    [SerializeField] private FoxHealthScript foxHealthScript;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 circlePosition = GroundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(circlePosition, JumpOffset, groundLayer);
        if (isGrounded && Mathf.Abs(rb.velocity.x) > 0.01f) foxAnim.SetBool("isRun", true);
        else foxAnim.SetBool("isRun", false);
    }
    public void Move(float direction, bool isJump)
    {
        if (direction < 0) transform.localScale = new Vector3(-1, 1, 1);
        if (direction > 0) transform.localScale = new Vector3(1, 1, 1);
        if (isJump) Jump();
        if (direction > 0.01f || direction < -0.01f) Movement(direction);
    }
    private void Jump()
    {
        if (isGrounded) {
            foxAnim.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x + 0.001f, JumpForce); 
        }
    }
    private void Movement(float direction)
    {
        if (isGrounded || rb.velocity.x != 0)
        {
            rb.velocity = new Vector2(curve.Evaluate(direction), rb.velocity.y);
        }
    }
}
