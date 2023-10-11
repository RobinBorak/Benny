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


  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    tr = GetComponent<Transform>();
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Trap"))
    {
      Die();
    }
    else if (collision.gameObject.CompareTag("Enemy"))
    {
      if (isInvincible)
      {
        collision.gameObject.GetComponent<Enemy>().Die();
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


  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Enemy"))
    {
      //if (transform.position.y > collision.transform.position.y)
      collision.gameObject.GetComponent<Enemy>().Die();
      rb.velocity = new Vector2(rb.velocity.x, 2f);
    }
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
    transform.localScale = new Vector3(1f, 1f, transform.localScale.z);
  }
}