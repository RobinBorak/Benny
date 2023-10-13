using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  private Animator animator;
  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void Die()
  {
    //Trigger die animation
    animator.SetTrigger("Die");
    GetComponent<BoxCollider2D>().enabled = false;
    //Destroy the enemy
    Destroy(gameObject, 1);
  }

  public void TakeDamage(int damage)
  {
    //Trigger take damage animation
    //animator.SetTrigger("TakeDamage");
    //Reduce health
    //Check if health is 0
    Die();
  }
}
