using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscores
{
  public Highscore level1 = new Highscore(1, 0);
  public Highscore level2 = new Highscore(2, 0);
  public Highscore level3 = new Highscore(3, 0);
  public Highscore level4 = new Highscore(4, 0);
  public Highscore level5 = new Highscore(5, 0);
  public Highscore level6 = new Highscore(6, 0);


  public Highscores(Highscores highscores)
  {
    level1 = highscores.level1;
    level2 = highscores.level2;
    level3 = highscores.level3;
    level4 = highscores.level4;
    level5 = highscores.level5;
    level6 = highscores.level6;
  }

  public Highscores()
  {
  }

}
