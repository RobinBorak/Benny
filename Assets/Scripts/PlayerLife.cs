using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
  private Rigidbody2D rb;
  private Animator anim;
  public bool isDead = false;
  private bool isInvincible = false;
  private Transform tr;
  private Vector3 originalScale;


  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    tr = GetComponent<Transform>();
    originalScale = tr.localScale;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Enemy"))
    {
      //if (transform.position.y > collision.transform.position.y)
      collision.gameObject.GetComponent<Enemy>().Die();
      rb.velocity = new Vector2(rb.velocity.x, 2f);
    }
    else
    {
      OnCollision(collision.gameObject);
    }
  }
  private void OnCollisionEnter2D(Collision2D collision)
  {
    OnCollision(collision.gameObject);
  }
  private void OnCollision(GameObject go)
  {
    if (go.CompareTag("Trap"))
    {
      Die();
    }
    else if (go.CompareTag("Enemy"))
    {
      if (isInvincible)
      {
        go.GetComponent<Enemy>().Die();
      }
      else
      {
        Die();
      }
    }
  }

  private void Die()
  {
    Debug.Log("Player died!");
    isDead = true;
    rb.bodyType = RigidbodyType2D.Static;
    anim.SetTrigger("Die");
    Invoke("GameOver", 2f);
  }

  private void RestartLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  private void GameOver()
  {
    RestartLevel();
  }


  public void IncreaseSizeAndStrength(float amount)
  {
    Debug.Log("Player increased size and strength!");
    isInvincible = true;
    tr.localScale = new Vector3(tr.localScale.x * amount, tr.localScale.y * amount, tr.localScale.z);
    Invoke("ResetInvincibility", 15f);
  }

  private void ResetInvincibility()
  {
    Debug.Log("Player is no longer invincible!");
    isInvincible = false;
    transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
  }
}