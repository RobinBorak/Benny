using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingObjects : MonoBehaviour
{
  [SerializeField] private GameObject objectToDrop;
  [SerializeField] private GameObject wayPointUp;
  [SerializeField] private GameObject wayPointDown;
  private float dropSpeed = 6f;
  private float moveUpSpeed = 1f;
  private bool isFalling = false;

  // Update is called once per frame
  void FixedUpdate()
  {
    if (isFalling)
    {
      DropObject();
    }
    else
    {
      MoveObjectUp();
    }
  }

  private void DropObject()
  {
    objectToDrop.transform.position = new Vector3(objectToDrop.transform.position.x, objectToDrop.transform.position.y - dropSpeed * Time.deltaTime, objectToDrop.transform.position.z);
    if (objectToDrop.transform.position.y <= wayPointDown.transform.position.y)
    {
      isFalling = false;
    }
  }

  private void MoveObjectUp()
  {
    objectToDrop.transform.position = new Vector3(objectToDrop.transform.position.x, objectToDrop.transform.position.y + moveUpSpeed * Time.deltaTime, objectToDrop.transform.position.z);
    if (objectToDrop.transform.position.y >= wayPointUp.transform.position.y)
    {
      isFalling = true;
    }
  }
}
