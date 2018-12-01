using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

  Rigidbody rbd;

  Transform parentPivot;

  public float speed;
  public float turnSpeed;

	// Use this for initialization
	void Start () {
    rbd = GetComponent<Rigidbody>();
    parentPivot = GetComponent<Transform>().transform.parent.transform;
	}
	
	// Update is called once per frame
	void Update () {
    var x = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;

    parentPivot.transform.Rotate(0, x, 0);

    rbd.AddForce(0, 0, speed);

	}
}
