using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    // Ignore Enemy collisions
    Physics2D.IgnoreLayerCollision(7, 7);

  }

  // Update is called once per frame
  void Update()
  {

  }
}
