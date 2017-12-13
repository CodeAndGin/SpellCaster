using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

	public bool enemyAlive;
	public GameObject enemy;
	public GameObject miniboss;
	private GameObject newEnemy;
	private levelController levels;
	public int enemyNumber;
	public int maxEnemies;

	public float speed = 2;

	// Use this for initialization
	void Start () {
		newEnemy = Instantiate(enemy, transform.position, Quaternion.identity) as GameObject;
		levels = GameObject.Find("LevelController").GetComponent<levelController>();
		enemyNumber = 0;
		maxEnemies = levels.level*5;
	}

	// Update is called once per frame
	void Update () {
		if (!enemyAlive && enemyNumber < maxEnemies) {
			StartCoroutine("spawn");
		} else if (!enemyAlive && enemyNumber == maxEnemies) {
			StartCoroutine("spawnMiniBoss");
		} else if (enemyAlive) {
			StopCoroutine("spawn");
			StopCoroutine("spawnMiniBoss");
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
		enemyNumber++;
	}

	IEnumerator spawnMiniBoss() {
		yield return new WaitForSeconds(3.0f);
		newEnemy = Instantiate(miniboss, transform.position, Quaternion.identity) as GameObject;
		enemyNumber ++;
	}

	void speedUp () {
		speed += 0.5f;
	}

	void slowDown () {
		speed = 1f;
	}
}
