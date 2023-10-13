using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
  public delegate void OnHasSwordChange();
  public static event OnHasSwordChange onHasSwordChange;

  public bool hasSword = false;
  private GameObject attackButton;

  public Player()
  {
    onHasSwordChange += SavePlayer;
  }

  public void GiveSword()
  {
    hasSword = true;
    onHasSwordChange?.Invoke();
  }

  public void RemoveSword()
  {
    hasSword = false;
    onHasSwordChange?.Invoke();
  }

  private void SavePlayer()
  {
    MainManager.Instance.SavePlayer();
  }


}
