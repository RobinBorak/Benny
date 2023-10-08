using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
  public int nextLevel = 0;
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      Debug.Log("Player reached the finish!");
      if (nextLevel > 0)
      {
        SceneManager.LoadScene("Level " + nextLevel);
      }
      else
      {
        SceneManager.LoadScene("Level Selector");
      }
    }
  }
}
