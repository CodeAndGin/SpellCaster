using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStateController : MonoBehaviour {

	public GameObject pausePanel, pauseButton;
	public bool paused;
	// Use this for initialization
	void Start () {
		paused = false;
	}

	// Update is called once per frame
	void Update () {
		//pauseGame();
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

	public void Pause()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
		paused = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
		paused = false;
    }
}
