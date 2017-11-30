using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

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
			StartCoroutine("spawn");
		} else if (enemyAlive) {
			StopCoroutine("spawn");
		}
	}

	void enemyIsAlive () {
		enemyAlive = true;
	}

	void enemyIsDead () {
		enemyAlive = false;
	}

	IEnumerator spawn() {
		yield return new WaitForSeconds(3.0f);
		newEnemy = Instantiate(enemy, transform.position, Quaternion.identity) as GameObject;
	}
}
