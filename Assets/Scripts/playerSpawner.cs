using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawner : MonoBehaviour {

	private bool playerAlive = true;
	public GameObject newPlayer;
	private GameObject makeNewPlayer;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (playerAlive == false) {
			StartCoroutine("spawn");
		}
		else if (playerAlive == true) StopCoroutine("spawn");
	}

	void playerIsDead () {
		playerAlive = false;
	}

	void playerIsAlive() {
		playerAlive = true;
	}

	IEnumerator spawn() {
		yield return new WaitForSeconds(3.0f);	//waits 3 seconds before the next line is called
		makeNewPlayer = Instantiate(newPlayer, transform.position, Quaternion.identity) as GameObject;
	}
}
