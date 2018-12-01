using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

  public TextMeshProUGUI timeText;
  float startTime;

  public float LevelTime;

	// Use this for initialization
	void Start () {
    startTime = Time.time;
    StartCoroutine(StartGame());
	}
	
	// Update is called once per frame
	void Update () {
    int time = Mathf.RoundToInt(LevelTime - Time.time);
    timeText.text = "Time Left: " + time.ToString();

  }

  IEnumerator StartGame() {
    yield return new WaitForSeconds(3f);
    print("GameStart");
  }
}
