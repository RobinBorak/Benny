using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingObjects2 : MonoBehaviour
{
  [SerializeField] private GameObject wayPointUp;
  [SerializeField] private float gravityScale = 15f;
  private float moveUpSpeed = 1f;
  private bool isFalling = false;
  private Rigidbody2D rb;

  // Start is called before the first frame update
  void Start()
  {
    rb = gameObject.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (isFalling)
    {
      DropObject();
    }
    else
    {
      MoveObjectUp();
    }
  }

  private void DropObject()
  {

    rb.gravityScale = gravityScale;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    Debug.Log("collision.gameObject.layer: " + collision.gameObject.layer);
    // Layer ground
    if (collision.gameObject.layer == 6)
    {
      isFalling = false;
    }
  }

  private void MoveObjectUp()
  {
    rb.gravityScale = 0;
    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + moveUpSpeed * Time.deltaTime, gameObject.transform.position.z);
    if (gameObject.transform.position.y >= wayPointUp.transform.position.y)
    {
      isFalling = true;
    }
  }
}
