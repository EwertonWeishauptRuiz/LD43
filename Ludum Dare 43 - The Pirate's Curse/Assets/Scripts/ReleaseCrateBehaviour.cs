using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseCrateBehaviour : MonoBehaviour {

  Rigidbody rbd;  
	// Use this for initialization
	void Start () {
    rbd = GetComponent<Rigidbody>();
    rbd.AddForce(transform.right * 0.2f, ForceMode.Impulse);
    rbd.useGravity = true;
  }
	
	// Update is called once per frame
	void Update () {

	}

  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Water")) {
      rbd.useGravity = false;
      rbd.isKinematic  = true;
    }
  }
}
