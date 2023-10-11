using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
  private int cherries = 0;
  private int apples = 0;

  private TextMeshProUGUI cherriesText;

  private void Start()
  {
    cherriesText = GameObject.Find("CheeriesText").GetComponent<TextMeshProUGUI>();
  }


  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Cherry"))
    {
      Destroy(collision.gameObject);
      cherries++;
      cherriesText.text = cherries.ToString();
    } else if (collision.gameObject.CompareTag("Apple"))
    {
      Destroy(collision.gameObject);
      apples++;
      GetComponent<PlayerLife>().IncreaseSizeAndStrength(2f);
    }
  }
}