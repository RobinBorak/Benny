using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCanvas : MonoBehaviour
{
  private static GameObject attackButton;
  private static GameObject leftButton;
  private static GameObject rightButton;
  private static GameObject jumpButton;
  private static BennyMovement bennyMovement;
  private static PlayerCombat playerCombat;
  // Start is called before the first frame update
  void Start()
  {
    leftButton = GameObject.Find("LeftButton");
    rightButton = GameObject.Find("RightButton");
    jumpButton = GameObject.Find("JumpButton");
    attackButton = GameObject.Find("PlayerMovementCanvas").transform.Find("AttackButton").gameObject;

    OnHasSwordChange();
    Player.onHasSwordChange += OnHasSwordChange;

  }
  

  private void OnHasSwordChange()
  {
    attackButton.SetActive(MainManager.Instance.GetPlayer().hasSword);
  }

  // Update is called once per frame
  void Update()
  {

  }
}
