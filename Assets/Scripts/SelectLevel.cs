using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{

  [SerializeField] private int level = 0;

  public void LoadLevel()
  {
    Debug.Log("Loading level " + level);
    UnityEngine.SceneManagement.SceneManager.LoadScene(level);
  }


}
