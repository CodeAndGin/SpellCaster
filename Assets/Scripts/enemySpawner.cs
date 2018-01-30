using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

	public bool enemyAlive;
	public GameObject enemy1;
    public GameObject enemy2;
    public GameObject miniboss;
    public GameObject[] enemies;
	private GameObject newEnemy;
	private levelController levels;
	public int enemyNumber;
	public int maxEnemies;

	public float speed = 2;
    public int health = 1;

	// Use this for initialization
	void Start () {
        enemies = new GameObject[2];
        enemies[0]=enemy1;
        enemies[1]=enemy2;
        newEnemy = Instantiate(enemies[(int)Math.Floor((double)UnityEngine.Random.Range(0,2))], transform.position, Quaternion.identity) as GameObject;
		levels = GameObject.Find("LevelController").GetComponent<levelController>();
		enemyNumber = 0;
		maxEnemies = levels.level*5;
	}

	// Update is called once per frame
	void Update () {
		if (!enemyAlive && enemyNumber < maxEnemies) {
			StartCoroutine("spawn");
		} else if (!enemyAlive && enemyNumber >= maxEnemies) {
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
        newEnemy = Instantiate(enemies[(int)Math.Floor((double)UnityEngine.Random.Range(0, 2))], transform.position, Quaternion.identity) as GameObject;
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
