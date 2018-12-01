using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateJump : MonoBehaviour {

  Rigidbody rbd;
  Animation anim;
  AudioSource scream;
  bool goDown;
	// Use this for initialization
	void Start () {
    rbd = GetComponent<Rigidbody>();
    scream = GetComponent<AudioSource>();
    StartCoroutine(WaitForRBD());
	}

  private void Update() {
    if (goDown) {
      transform.Translate(-Vector3.up * Time.deltaTime, Space.World);
    }
  }

  IEnumerator WaitForRBD() {
    yield return new WaitForSeconds(.3f);
    gameObject.transform.parent = null;
    yield return new WaitForSeconds(.3f);
    scream.Play();    
    yield return new WaitForSeconds(.3f);
    goDown = true;
    
    yield return new WaitForSeconds(2f);
    yield return new WaitForSeconds(1f);    
    Destroy(gameObject);
  }
}
