using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
  private int nextLevel = 0;
  private int maxLevel = 2;
  private void Start()
  {
    nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    if (nextLevel > maxLevel)
    {
      nextLevel = -1;
    }
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      Debug.Log("Player reached the finish!");
      if (nextLevel == -1)
      {
        Debug.Log("You won the game!");
        SceneManager.LoadScene("Level Selector");
      }
      else
      {
        SceneManager.LoadScene(nextLevel);
      }
    }
  }
}
