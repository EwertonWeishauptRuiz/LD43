using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehaviour : MonoBehaviour {

  Rigidbody rbd;

  [Header("Handling Setup")]
  public float maxTurnPoint = .5f;
  public float speed = 5;
  public float turnSpeed;

  [Header("Amounts")]
  public int crates;
  public int crew;

  int sailStatus;
  bool canThrow, gameOver;

  [Header("Prefabs and References")]
  public Transform exitPointCrate;
  public GameObject cratePrefab, piratePrefab;
  public GameObject[] exitPointsPirate;

  [Header("UI Elements")]
  public TextMeshProUGUI crateText;
  public TextMeshProUGUI crewText;

  float horizontalInput;

	// Use this for initialization
	void Start () {
    sailStatus = 2;
    rbd = GetComponent<Rigidbody>();
    rbd.maxAngularVelocity = maxTurnPoint;
    canThrow = true;
	}
	
	// Update is called once per frame
	void Update () {
    horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * turnSpeed;

    SetShipSpeed();

    if (Input.GetKeyDown(KeyCode.W) && sailStatus < 2) {
      sailStatus++;
    }
    if (Input.GetKeyDown(KeyCode.S) && sailStatus > 0) {
      sailStatus--;
    }

    // Expell Crate
    if (Input.GetMouseButtonDown((0)) && crates > 0 && canThrow){
      StartCoroutine(ExpellCrates());
    }

    //Expell crew member
    if (Input.GetMouseButtonDown((1)) && crew > 0 && canThrow) {
      StartCoroutine(ExpellPirate());
      crew--;
    }

    // UI Elements Renderers
    UIElements();
    if (gameOver && speed >= 0) {
      speed -= Time.deltaTime;
    }

  }

  private void FixedUpdate() {
    rbd.AddTorque(0, horizontalInput * turnSpeed, 0);
    rbd.velocity = new Vector3(0, 0, speed);

    float velocityMagnitude = rbd.velocity.magnitude;    

    rbd.velocity = transform.forward * velocityMagnitude;
  }

  void SetShipSpeed() {
    switch (sailStatus) {
      case 0:
        speed = 1f;
      maxTurnPoint = 1.2f;
        break;
      case 1:
        speed = 2.5f;
      maxTurnPoint = .8f;
        break;
      case 2:
        speed = 5;
      maxTurnPoint = .5f;
        break;
    }
  }

  IEnumerator ExpellCrates() {
    canThrow = false;
    GameObject.Instantiate(cratePrefab, exitPointCrate.transform.position, Quaternion.identity);
    crates--;
    yield return new WaitForSeconds(1f);
    canThrow = true;
    StopCoroutine(ExpellCrates());
  }

  IEnumerator ExpellPirate() {
    canThrow = false;
    int randomNumber = Random.Range(0, exitPointsPirate.Length - 1);
    int rotationY = 0;
    if (randomNumber <= 3) {
      rotationY = 90;
    } else {
      rotationY = -90;
    }
    GameObject pirate = Instantiate(piratePrefab, exitPointsPirate[randomNumber].transform.position, Quaternion.Euler(0, rotationY, 0));
    pirate.transform.parent = gameObject.transform;
    crates--;
    yield return new WaitForSeconds(1f);
    canThrow = true;
    StopCoroutine(ExpellPirate());
  }

  void UIElements() {
    crateText.text = "Crates: " + crates.ToString();
    crewText.text = "Crates: " + crew.ToString();
  }

  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Crate")) {
      print("Crate Picked");
      crates++;
    }

    if (other.CompareTag("EndTrigger")) {
      sailStatus = -1;
      gameOver = true;                  
    }
  }
}
