using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{

  [SerializeField] private int level = 0;

  public void LoadLevel()
  {
    Debug.Log("Loading level " + level);

    // Remove sword on first level for demo purposes
    if (level == 1)
      MainManager.Instance.GetPlayer().RemoveSword();

    UnityEngine.SceneManagement.SceneManager.LoadScene(level);
  }


}
