using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
  [SerializeField] private GameObject target;
  [SerializeField] private GameObject enemy;

  // Update is called once per frame
  void Update()
  {
    FollowTarget();
    //DemoGoToTarget();

  }

  void FollowTarget()
  {
    transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
  }


  void DemoGoToTarget()
  {
    // Follow target. 
    // After 1 seconds slowly move camera to the enemy and then back again.
    if (Time.time < 1)
    {
      FollowTarget();
    }
    else if (Time.time < 6)
    {
      Vector3 targetPosition = new Vector3(enemy.transform.position.x, enemy.transform.position.y, transform.position.z);
      transform.position = Vector3.Lerp(transform.position, targetPosition, 0.01f);
    }
    else if (Time.time < 11)
    {
      Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
      transform.position = Vector3.Lerp(transform.position, targetPosition, 0.01f);
    }
    else
    {
      FollowTarget();
    }
  }
}
