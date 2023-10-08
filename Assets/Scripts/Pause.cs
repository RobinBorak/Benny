using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{

  public static bool isPaused = false;
  public GameObject pauseMenuUI;

  void Start()
  {
  }

  public void TogglePause()
  {
    if (isPaused)
    {
      Resume();
    }
    else
    {
      PauseGame();
    }
  }

  public void Resume()
  {
    pauseMenuUI.SetActive(false);
    isPaused = false;
    Time.timeScale = 1f;
  }

  public void PauseGame()
  {
    pauseMenuUI.SetActive(true);
    isPaused = true;
    Time.timeScale = 0f;
  }

  public void MainMenu()
  {
    Resume();
    UnityEngine.SceneManagement.SceneManager.LoadScene("Level Selector");
  }

}
