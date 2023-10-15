using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/**
* Currently only works shooting left to right 
**/

public class FireBlaster : MonoBehaviour
{

  [SerializeField] private GameObject fireballPrefab;
  private float fireballSpeed = 5f;
  private float fireballSpawnTime = 4f;
  private GameObject blaster;
  
  // Start is called before the first frame update
  void Start()
  {
    blaster = gameObject.transform.Find("Blaster").gameObject;
    Fire();
  }

  // Update is called once per frame
  void Update()
  {
  }

  public void Fire()
  {
    StartCoroutine(FireBlasterCoroutine());
  }

  IEnumerator FireBlasterCoroutine()
  {
    GameObject fireball = Instantiate(fireballPrefab, blaster.transform.position, Quaternion.identity);
    fireball.transform.Rotate(0, 0, -90);
    fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(fireballSpeed, 0);
    fireball.tag = "Trap"; 
    yield return new WaitForSeconds(fireballSpawnTime);
    StartCoroutine(FireBlasterCoroutine());
  }
}
