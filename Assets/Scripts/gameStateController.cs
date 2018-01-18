using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStateController : MonoBehaviour {

	public bool paused;
	// Use this for initialization
	void Start () {
		paused = false;
		DontDestroyOnLoad(gameObject);
	}

	// Update is called once per frame
	void Update () {
		pauseGame();
	}

	void pauseGame () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (Time.timeScale == 1) {
				Time.timeScale = 0;
				paused = true;
			} else if (Time.timeScale == 0) {
				Time.timeScale = 1;
				paused = false;
			}
		}
	}
}
