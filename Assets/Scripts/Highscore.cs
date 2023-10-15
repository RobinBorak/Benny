using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore
{
  public int level = 0;
  public int cherries = 0;

  public Highscore(int level, int cherries)
  {
    this.level = level;
    this.cherries = cherries;
  }
}
