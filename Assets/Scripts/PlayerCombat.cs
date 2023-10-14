using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
  private Animator anim;
  private float attackSpeed = 1f;
  private float attackRange = 2f;
  private bool isAttacking = false;

  private static GameObject sword;
  private Transform attackPoint;

  private void Start()
  {
    anim = GetComponent<Animator>();
    sword = GameObject.Find("Weapon").transform.Find("Sword").gameObject;
    attackPoint = sword.transform.Find("AttackPoint").transform;

    ToggleSword();
    Player.onHasSwordChange += ToggleSword; 
  }

  private void ToggleSword()
  {
    sword.gameObject.SetActive(MainManager.Instance.GetPlayer().hasSword);
  }

  public void Attack()
  {
    if (!isAttacking)
    {
      anim.SetTrigger("Attack");
      Swing();
      isAttacking = true;
    }
  }

  private void Swing()
  {
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask("Enemy"));
    foreach (Collider2D enemy in hitEnemies)
    {
      Debug.Log("We hit " + enemy.name);
      enemy.GetComponent<Enemy>().TakeDamage(1);
    }

    Invoke("ResetIsAttacking", attackSpeed);
  }

  private void ResetIsAttacking()
  {
    isAttacking = false;
  }
}
