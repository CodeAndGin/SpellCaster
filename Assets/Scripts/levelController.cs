using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelController : MonoBehaviour {
	private string levelName;
	public int level;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		level = 1;
		levelName = "level";
	}

	// Update is called once per frame
	void Update () {

	}

	void NextLevel() {
		level++;
		levelName = "Level" + level;
		SceneManager.LoadScene(levelName);
	}
}
