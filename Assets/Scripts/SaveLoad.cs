using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad
{
  private static List<Highscore> highscores = new List<Highscore>();
  private static List<LevelStats> levelStats = new List<LevelStats>();

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


  public static void SaveLevelStats()
  {
    Debug.Log("Saving level stats...");
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(Application.persistentDataPath + "/levelStats.gd");
    bf.Serialize(file, SaveLoad.levelStats);
    file.Close();
  }
  public static List<LevelStats> GetLevelStats()
  {
    if (levelStats.Count > 0)
    {
      Debug.Log("Return cached level stats");
      return levelStats;
    }
    else
    {
      return LoadLevelStats();
    }

  }
  public static List<LevelStats> LoadLevelStats()
  {

    Debug.Log("Load level stats from file");
    if (File.Exists(Application.persistentDataPath + "/levelStats.gd"))
    {
      Debug.Log("File exists");
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Open(Application.persistentDataPath + "/levelStats.gd", FileMode.Open);
      SaveLoad.levelStats = (List<LevelStats>)bf.Deserialize(file);
      file.Close();
    }
    return levelStats;
  }

  public static LevelStats GetLevelStats(int level)
  {
    foreach (LevelStats levelStat in levelStats)
    {
      if (levelStat.level == level)
      {
        return levelStat;
      }
    }
    return new LevelStats(level);
  }

  public static void SetLevelStatCompleted(int level)
  {
    foreach (LevelStats levelStat in levelStats)
    {
      if (levelStat.level == level)
      {
        levelStat.completed = true;
        return;
      }
    }
    levelStats.Add(new LevelStats(level, 0, true));
  }

  public static void LevelStatAddDeath(int level)
  {
    foreach (LevelStats levelStat in levelStats)
    {
      if (levelStat.level == level)
      {
        levelStat.deaths++;
        return;
      }
    }
    levelStats.Add(new LevelStats(level, 1, false));
  }

}
