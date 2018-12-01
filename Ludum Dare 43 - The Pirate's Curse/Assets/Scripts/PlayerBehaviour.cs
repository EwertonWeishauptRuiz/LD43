using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

  Rigidbody rbd; 

  public float speed;
  public float turnSpeed;

  [Header("Amounts")]
  public int crates;

  float horizontalInput;

	// Use this for initialization
	void Start () {
    rbd = GetComponent<Rigidbody>();    
	}
	
	// Update is called once per frame
	void Update () {
    horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * turnSpeed;      
  }

  private void FixedUpdate() {
    rbd.AddTorque(0, horizontalInput * turnSpeed, 0);
    rbd.velocity = new Vector3(0, 0, speed);

    float velocityMagnitude = rbd.velocity.magnitude;

    rbd.velocity = transform.forward * velocityMagnitude;
  }
}
