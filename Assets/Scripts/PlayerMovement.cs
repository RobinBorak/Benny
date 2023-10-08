using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] private LayerMask jumpableGround;

  private Rigidbody2D rb;
  private SpriteRenderer sprite;
  private Animator anim;
  private BoxCollider2D coll;
  private PlayerLife playerLife;

  private float dirX = 0f;
  private float moveSpeed = 7f;
  private float jumpForce = 5f;

  private enum MovementState { idle, running, jumping, falling }

  // Start is called before the first frame update
  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    sprite = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
    coll = GetComponent<BoxCollider2D>();
    playerLife = GetComponent<PlayerLife>();
  }

  // Update is called once per frame
  private void Update()
  {
    if (playerLife.isDead)
    {
      return;
    }

    UpdateAnimationState();
  }

  private void Movement()
  {
    dirX = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    if (Input.GetButtonDown("Jump") && IsGrounded())
    {
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
  }

  // hold left ui button to move left
  public void MoveLeft()
  {
    dirX = -1;
    rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
  }

  // hold right ui button to move right
  public void MoveRight()
  {
    dirX = 1;
    rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
  }

  // release left or right ui button to stop moving
  public void StopMoving()
  {
    dirX = 0;
    rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
  }

  // tap jump ui button to jump
  public void Jump()
  {
    if (IsGrounded())
    {
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
  }


  private void UpdateAnimationState()
  {
    MovementState state;

    if (dirX > 0f)
    {
      state = MovementState.running;
      sprite.flipX = false;
    }
    else if (dirX < 0f)
    {
      state = MovementState.running;
      sprite.flipX = true;
    }
    else
    {
      state = MovementState.idle;
    }

    if (rb.velocity.y > .1f)
    {
      state = MovementState.jumping;
    }
    else if (rb.velocity.y < -.1f)
    {
      state = MovementState.falling;
    }

    anim.SetInteger("state", (int)state);
  }

  bool IsGrounded()
  {
    return Physics2D.BoxCast(
      coll.bounds.center,
      coll.bounds.size,
      0f,
      Vector2.down,
      .1f,
      jumpableGround
    ).collider != null;
  }
}