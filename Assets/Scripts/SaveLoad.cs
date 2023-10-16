using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad
{
  private static List<Highscore> highscores = new List<Highscore>();

  public static void SaveHighscores()
  {
    Debug.Log("Saving highscores...");
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(Application.persistentDataPath + "/highscores.gd");
    bf.Serialize(file, SaveLoad.highscores);
    file.Close();
  }

  public static List<Highscore> GetHighscores()
  {
    if (highscores.Count > 0)
    {
      Debug.Log("Return cached highscores");
      return highscores;
    }
    else
    {
      return LoadHighscores();
    }

  }
  public static List<Highscore> LoadHighscores()
  {

    Debug.Log("Load highscores from file");
    if (File.Exists(Application.persistentDataPath + "/highscores.gd"))
    {
      Debug.Log("File exists");
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Open(Application.persistentDataPath + "/highscores.gd", FileMode.Open);
      SaveLoad.highscores = (List<Highscore>)bf.Deserialize(file);
      file.Close();
    }
    return highscores;
  }

  public static Highscore GetHighscore(int level)
  {
    foreach (Highscore highscore in highscores)
    {
      if (highscore.level == level)
      {
        return highscore;
      }
    }
    return new Highscore(level, 0);
  }

  public static void SetHighscore(int level, int cherries)
  {
    foreach (Highscore highscore in highscores)
    {
      if (highscore.level == level)
      {
        highscore.cherries = cherries;
        return;
      }
    }
    highscores.Add(new Highscore(level, cherries));
  }
}
