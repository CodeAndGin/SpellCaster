using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

	private float timeTillSpawn;
	private bool enemyAlive;
	public GameObject enemy;
	private GameObject newEnemy;


	// Use this for initialization
	void Start () {
		newEnemy = Instantiate(enemy, transform.position, Quaternion.identity) as GameObject;
	}

	// Update is called once per frame
	void Update () {
		if (!enemyAlive) {
			spawn();
		} else if (enemyAlive) {
			timeTillSpawn = 3.0f;
		}
	}

	void enemyIsAlive () {
		enemyAlive = true;
	}

	void enemyIsDead () {
		enemyAlive = false;
	}

	void spawn() {
		timeTillSpawn -= Time.deltaTime;
		if (timeTillSpawn <= 0.0f) {
			newEnemy = Instantiate(enemy, transform.position, Quaternion.identity) as GameObject;
		}
	}
}
