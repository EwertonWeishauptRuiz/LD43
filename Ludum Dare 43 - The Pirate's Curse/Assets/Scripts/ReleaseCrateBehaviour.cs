using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseCrateBehaviour : MonoBehaviour {

  Rigidbody rbd;
  public bool released;
	// Use this for initialization
	void Start () {
    rbd = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
    if (released) {
      rbd.AddForce(transform.right * 0.2f, ForceMode.Impulse);
      rbd.useGravity = true;
    }
	}
}
