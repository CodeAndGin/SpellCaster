using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelController : MonoBehaviour {
	private string levelName;
	public int level;
	public Text complete;
    bool textFound = false;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		levelName = "level";
		complete = GameObject.Find("LevelCompleteText").GetComponent<Text>();
	}

    void Update()
    {
        if (GameObject.Find("LevelCompleteText") != null && !textFound) {
            complete = GameObject.Find("LevelCompleteText").GetComponent<Text>();
            textFound = true;
        }
        else
        {
            textFound = false;
        }
    }

	void nLevel() {
		StartCoroutine("NextLevel");
	}

	IEnumerator NextLevel() {	/*level is changing here*/
		complete.text = "LEVEL " + level + " COMPLETE!\n Next Level in " + 3;
		yield return new WaitForSecondsRealtime(1.0f);
		complete.text = "LEVEL " + level + " COMPLETE!\n Next Level in " + 2;
		yield return new WaitForSecondsRealtime(1.0f);
		complete.text = "LEVEL " + level + " COMPLETE!\n Next Level in " + 1;
		yield return new WaitForSecondsRealtime(1.0f);
		level++;
		levelName = "Level" + level;
		SceneManager.LoadScene(levelName);
		StopCoroutine("NextLevel");
	}

    public void startGame ()
    {
        SceneManager.LoadScene(1);
    }
}
