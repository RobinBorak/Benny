using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
  public static MainManager Instance;
  public static Player player;

  private static int currentDeathCount = 0;
  private static int currentLevel = 0;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      LoadPlayer();
      SaveLoad.LoadLevelStats();
      SaveLoad.LoadHighscores();
      Physics2D.IgnoreLayerCollision(7, 7);
      DontDestroyOnLoad(gameObject);
    }
  }

  private void OnApplicationQuit()
  {
    Debug.Log("Application ending...");
    SavePlayer();
    SaveLoad.SaveHighscores();
    SaveLoad.SaveLevelStats();
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


  public int CurrentDeathCount
  {
    get
    {
      return currentDeathCount;
    }
    set
    {
      currentDeathCount = value;
    }
  }

  public int CurrentLevel
  {
    get
    {
      return currentLevel;
    }
    set
    {
      currentLevel = value;
    }
  }
}
