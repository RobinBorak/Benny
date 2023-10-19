using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnInXSeconds : MonoBehaviour
{
  [SerializeField] private int seconds = 5;
  [SerializeField] private GameObject objectToSpawn;

  void Start()
  {
    Invoke("Spawn", seconds);
  }
  void Spawn()
  {
    objectToSpawn.SetActive(true);
  }
}
