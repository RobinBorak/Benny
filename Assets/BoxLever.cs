using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLever : MonoBehaviour
{

  [SerializeField] private Sprite activatedSprite;
  [SerializeField] private GameObject block;

  private bool activated = false;
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!activated && other.gameObject.CompareTag("Player"))
    {
      Debug.Log("Box hit lever");
      activated = true;
      GetComponent<Animator>().SetTrigger("Activate");
      GetComponent<SpriteRenderer>().sprite = activatedSprite;

      //disable boxcollider on block
      block.GetComponent<BoxCollider2D>().enabled = false;
      Destroy(block, 2f);
    }
  }
}
