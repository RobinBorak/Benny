using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Finish : MonoBehaviour
{
  private int nextLevel = 0;
  private int maxLevel = 6;
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
      SetHighscore();
      Debug.Log("Player reached the finish! Go to next level " + nextLevel);
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

  private void SetHighscore()
  {
    TextMeshProUGUI cherryText = GameObject.Find("CheeriesText").GetComponent<TextMeshProUGUI>();
    int cherries = int.Parse(cherryText.text);
    MainManager.Instance.AddHighscore(SceneManager.GetActiveScene().buildIndex, cherries);
  }
}
