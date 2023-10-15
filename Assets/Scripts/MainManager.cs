using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
  public static MainManager Instance;
  public static Player player;
  public static Highscores highscores = new Highscores();

  public delegate void OnHighscoresLoaded();
  public static event OnHighscoresLoaded onHighscoresLoaded;


  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      LoadPlayer();
      LoadHighscores();
      Physics2D.IgnoreLayerCollision(7, 7);
      DontDestroyOnLoad(gameObject);
    }
  }

  private void OnApplicationQuit()
  {
    Debug.Log("Application ending...");
    SavePlayer();
    SaveHighscores();
  }

  public Player GetPlayer()
  {
    return player;
  }

  public void SavePlayer()
  {
    Debug.Log("Saving player...");
    string jsonData = JsonUtility.ToJson(player);
    PlayerPrefs.SetString("Player", jsonData);
    PlayerPrefs.Save();
  }

  private void LoadPlayer()
  {
    player = new Player();
    if (PlayerPrefs.HasKey("Player"))
    {
      string jsonData = PlayerPrefs.GetString("Player");
      JsonUtility.FromJsonOverwrite(jsonData, player);
    }
    else
    {
      player = new Player();
    }
  }

  private void LoadHighscores()
  {
    if (PlayerPrefs.HasKey("Highscores"))
    {
      string jsonData = PlayerPrefs.GetString("Highscores");
      Debug.Log("jsonData: " + jsonData);
      if (jsonData == null || jsonData == "")
      {
        Debug.Log("4");
      }
      else
      {
        Debug.Log("5");
        JsonUtility.FromJsonOverwrite(jsonData, highscores);
      }
    }
    Debug.Log("highscores loaded");
    Debug.Log(highscores);
    onHighscoresLoaded?.Invoke(); 
  }

  public void SaveHighscores()
  {
    Debug.Log("Saving highscores...");
    string jsonData = JsonUtility.ToJson(highscores);
    PlayerPrefs.SetString("Highscores", jsonData);
    PlayerPrefs.Save();
  }

  public void AddHighscore(int level, int cherries)
  {
    Debug.Log("Adding highscore for level " + level + " with " + cherries + " cherries");

    switch (level)
    {
      case 1:
        if (cherries > highscores.level1.cherries)
          highscores.level1.cherries = cherries;
        break;
      case 2:
        if (cherries > highscores.level2.cherries)
          highscores.level2.cherries = cherries;
        break;
      case 3:
        if (cherries > highscores.level3.cherries)
          highscores.level3.cherries = cherries;
        break;
      case 4:
        if (cherries > highscores.level4.cherries)
          highscores.level4.cherries = cherries;
        break;
      case 5:
        if (cherries > highscores.level5.cherries)
          highscores.level5.cherries = cherries;
        break;
      case 6:
        if (cherries > highscores.level6.cherries)
          highscores.level6.cherries = cherries;
        break;
      default:
        Debug.Log("Level " + level + " not found");
        break;
    }

    SaveHighscores();
  }

  public Highscores GetHighscores()
  {
    return highscores;
  }

  public Highscore GetHighscore(int level)
  {
    Debug.Log("Getting highscore for level " + level);
    switch (level)
    {
      case 1:
        return highscores.level1;
      case 2:
        return highscores.level2;
      case 3:
        return highscores.level3;
      case 4:
        return highscores.level4;
      case 5:
        return highscores.level5;
      case 6:
        return highscores.level6;
      default:
        Debug.Log("Level " + level + " not found");
        return null;
    }
  }

}
