using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawner : MonoBehaviour {

	private float timeTillSpawn = 3.0f;
	private bool playerAlive = true;
	public GameObject newPlayer;
	private GameObject makeNewPlayer;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (playerAlive == false) {
			spawn();
		}
		else if (playerAlive == true) timeTillSpawn = 3.0f;
	}

	void playerIsDead () {
		playerAlive = false;
	}

	void playerIsAlive() {
		playerAlive = true;
	}

	void spawn() {
		timeTillSpawn -= Time.deltaTime;
		if (timeTillSpawn <= 0.0f) {
			makeNewPlayer = Instantiate(newPlayer, transform.position, Quaternion.identity) as GameObject;
		}
	}
}
