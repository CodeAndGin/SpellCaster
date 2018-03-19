using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endController : MonoBehaviour {
    public GameObject text1;

	// Use this for initialization
	void Start () {
        StartCoroutine("Ending");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(2f);
        text1.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("menu");
    }
}
