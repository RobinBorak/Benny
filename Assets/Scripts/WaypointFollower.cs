using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
  [SerializeField] private GameObject[] waypoints;
  [SerializeField] private float speed = 2f;
  private int currentWaypointIndex = 0;
  private bool gameObjectIsEnemy = false;

  private void Start()
  {
    if (gameObject.GetComponent<Enemy>() != null)
    {
      gameObjectIsEnemy = true;
    }
  }


  private void Update()
  {
    if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
    {
      currentWaypointIndex++;
      if (currentWaypointIndex >= waypoints.Length)
      {
        currentWaypointIndex = 0;
      }
      if (gameObjectIsEnemy)
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }
    transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
  }
}