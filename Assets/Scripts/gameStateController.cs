using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStateController : MonoBehaviour {

	// Use this for initialization
	void Start () {
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
			} else if (Time.timeScale == 0) {
				Time.timeScale = 1;
			}
		}
	}
}
