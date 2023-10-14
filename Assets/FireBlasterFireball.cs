using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlasterFireball : MonoBehaviour
{

  // On hit terrain, destroy
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.layer == 6)
    {
      Destroy(gameObject);
    }
  }
}
