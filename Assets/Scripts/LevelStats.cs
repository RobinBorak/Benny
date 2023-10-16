using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelStats
{
  public int level = 0;
  public int deaths = 0;
  public bool completed = false;

  public LevelStats(int level, int deaths, bool completed)
  {
    this.level = level;
    this.deaths = deaths;
    this.completed = completed;
  }

  public LevelStats(int level)
  {
    this.level = level;
    this.deaths = 0;
    this.completed = false;
  }

}
