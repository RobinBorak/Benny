using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
  public static MainManager Instance;
  public static Player player;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      LoadPlayer();
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

}
