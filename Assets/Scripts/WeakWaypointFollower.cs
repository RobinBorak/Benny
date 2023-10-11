using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakWaypointFollower : MonoBehaviour
{
  [SerializeField] private GameObject[] waypoints;
  private int currentWaypointIndex = 0;
  private bool isPaused = false;

  [SerializeField] private float speed = 4f;

  private void Update()
  {
    if (isPaused)
    {
      return;
    }
    if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
    {
      currentWaypointIndex++;
      if (currentWaypointIndex >= waypoints.Length)
      {
        currentWaypointIndex = 0;
      }
    }
    transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      isPaused = true;
    }
  }
  void OnTriggerExit2D(Collider2D other)
  { 
    if (other.gameObject.CompareTag("Player"))
    {
      isPaused = false;
    }
  }
}