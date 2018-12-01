﻿using System.Collections;
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

  [Header("UI Elements")]
  public TextMeshProUGUI crateText;
  public TextMeshProUGUI crewText;

  float horizontalInput;

	// Use this for initialization
	void Start () {
    sailStatus = 2;
    rbd = GetComponent<Rigidbody>();
    rbd.maxAngularVelocity = maxTurnPoint;
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


    // UI Elements Renderers
    UIElements();
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
        speed = 2.5f;
        break;
      case 1:
        speed = 5;
        break;
      case 2:
        speed = 10;
        break;
    }
  }

  void UIElements() {
    crateText.text = "Crates: " + crates.ToString();
    crewText.text = "Crates: " + crew.ToString();
  }
}
