using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endController : MonoBehaviour {
    public GameObject text1;
    bool isEnding = false;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine("Ending");
	}
	
	// Update is called once per frame
	void Update () {
        if (!isEnding) StartCoroutine("Ending");
	}

    IEnumerator Ending()
    {
        isEnding = true;
        yield return new WaitForSecondsRealtime(2f);
        text1.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene("menu");
        Time.timeScale= 1f;
    }
}
