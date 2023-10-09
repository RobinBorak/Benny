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
  private float jumpForce = 7f;
  private bool moveLeft = false;
  private bool moveRight = false;

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
  private void FixedUpdate()
  {
    if (playerLife.isDead)
    {
      return;
    }

    InitMovement();
    UpdateAnimationState();
  }

  private void InitMovement()
  {
    dirX = moveLeft ? -1 : moveRight ? 1 : 0;
    //dirX = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    if (Input.GetButtonDown("Jump") && IsGrounded())
    {
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
  }

  // hold left ui button to move left
  public void MoveLeft()
  {
    moveLeft = true;
  }

  // hold right ui button to move right
  public void MoveRight()
  {
    moveRight = true;
  }

  // release left or right ui button to stop moving
  public void StopMoving()
  {
    moveLeft = false;
    moveRight = false;
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

    if (moveRight)
    {
      state = MovementState.running;
      sprite.flipX = false;
    }
    else if (moveLeft)
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