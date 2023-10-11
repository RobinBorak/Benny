using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BennyMovement : MonoBehaviour
{
  private LayerMask jumpableGround;

  private Rigidbody2D rb;
  private Transform tr;
  private Animator anim;
  private CapsuleCollider2D coll;
  private PlayerLife playerLife;

  private float dirX = 0f;
  private float moveSpeed = 3f;
  private float jumpForce = 7f;
  private bool moveLeft;
  private bool moveRight;

  private enum MovementState { idle, running, jumping, falling }

  // Start is called before the first frame update 
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    tr = GetComponent<Transform>();
    anim = GetComponent<Animator>();
    coll = GetComponent<CapsuleCollider2D>();
    playerLife = GetComponent<PlayerLife>();
    jumpableGround = LayerMask.GetMask("Ground");
  }

  void FixedUpdate()
  {
    if (playerLife.isDead)
    {
      return;
    }
    InitMovement();
    UpdateAnimationState();

    // For testing purposes
    if(Input.GetButtonDown("Jump") )
    {
      Jump();
    }
  }

  private void InitMovement()
  {
    //Movement
    dirX = moveLeft ? -1 : moveRight ? 1 : 0;
    rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
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
      //tr.localScale = new Vector2(-1, 1);
      tr.localScale = new Vector3(-1, 1, 1);
    }
    else if (moveLeft)
    {
      state = MovementState.running;
      //tr.localScale = new Vector2(1, 1);
      tr.localScale = new Vector3(1, 1, 1);
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
