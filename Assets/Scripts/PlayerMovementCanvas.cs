using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    playerCombat = GameObject.Find("Benny").GetComponent<PlayerCombat>();
    bennyMovement = GameObject.Find("Benny").GetComponent<BennyMovement>();

    InitMovement();

    OnHasSwordChange();
    Player.onHasSwordChange += OnHasSwordChange;

  }

  private void InitMovement()
  {
    //On leftButton pointer down
    EventTrigger leftTrigger = leftButton.GetComponent<EventTrigger>();
    EventTrigger.Entry leftPointerDownEntry = new EventTrigger.Entry();
    leftPointerDownEntry.eventID = EventTriggerType.PointerDown;
    leftPointerDownEntry.callback.AddListener((data) => { bennyMovement.MoveLeft(); });
    leftTrigger.triggers.Add(leftPointerDownEntry);

    //On leftButton pointer up
    EventTrigger.Entry leftPointerUpEntry = new EventTrigger.Entry();
    leftPointerUpEntry.eventID = EventTriggerType.PointerUp;
    leftPointerUpEntry.callback.AddListener((data) => { bennyMovement.StopMoving(); });
    leftTrigger.triggers.Add(leftPointerUpEntry);

    //On rightButton pointer down
    EventTrigger rightTrigger = rightButton.GetComponent<EventTrigger>();
    EventTrigger.Entry rightPointerDownEntry = new EventTrigger.Entry();
    rightPointerDownEntry.eventID = EventTriggerType.PointerDown;
    rightPointerDownEntry.callback.AddListener((data) => { bennyMovement.MoveRight(); });
    rightTrigger.triggers.Add(rightPointerDownEntry);

    //On rightButton pointer up
    EventTrigger.Entry rightPointerUpEntry = new EventTrigger.Entry();
    rightPointerUpEntry.eventID = EventTriggerType.PointerUp;
    rightPointerUpEntry.callback.AddListener((data) => { bennyMovement.StopMoving(); });
    rightTrigger.triggers.Add(rightPointerUpEntry);

    //On jumpButton pointer down
    EventTrigger jumpTrigger = jumpButton.GetComponent<EventTrigger>();
    EventTrigger.Entry jumpPointerDownEntry = new EventTrigger.Entry();
    jumpPointerDownEntry.eventID = EventTriggerType.PointerDown;
    jumpPointerDownEntry.callback.AddListener((data) => { bennyMovement.Jump(); });
    jumpTrigger.triggers.Add(jumpPointerDownEntry);

    //On attackButton pointer down
    EventTrigger attackTrigger = attackButton.GetComponent<EventTrigger>();
    EventTrigger.Entry attackPointerDownEntry = new EventTrigger.Entry();
    attackPointerDownEntry.eventID = EventTriggerType.PointerDown;
    attackPointerDownEntry.callback.AddListener((data) => { playerCombat.Attack(); });
    attackTrigger.triggers.Add(attackPointerDownEntry);

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
