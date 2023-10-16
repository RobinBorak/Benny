using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighscore : MonoBehaviour
{
  private TextMeshProUGUI textMesh;
  public int level;
  // Start is called before the first frame update
  void Start()
  {
    textMesh = GetComponent<TextMeshProUGUI>();
    SetText();
  }

  private void SetText()
  {
    Highscore highscore = SaveLoad.GetHighscore(level);
    Debug.Log("Highscore for level " + level + ": " + highscore.cherries);
    textMesh.text = highscore.cherries.ToString();
  }
}
