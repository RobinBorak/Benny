using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsLevelAvailable : MonoBehaviour
{
  private Button button;
  [SerializeField] private int level = 0;
  // Start is called before the first frame update
  void Start()
  {
    button = GetComponent<Button>();
    LevelStats levelStats = SaveLoad.GetLevelStats(level-1);
    if (levelStats.completed)
    {
      button.interactable = true;
    }
    else
    {
      button.interactable = false;
    }

  }

  // Update is called once per frame
  void Update()
  {

  }
}
