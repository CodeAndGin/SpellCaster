﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

	public bool enemyAlive;
	public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject[] enemies;
	private GameObject newEnemy;
	private levelController levels;
	public int enemyNumber;
	public int maxEnemies;

	public float speed = 2;
    public int health = 1;
    bool levelup = true;

	// Use this for initialization
	void Start () {
        enemies = new GameObject[3];
        enemies[0]=enemy1;
        enemies[1]=enemy2;
        enemies[2] = enemy3;
        newEnemy = Instantiate(enemies[(int)Math.Floor((double)UnityEngine.Random.Range(0,2))], transform.position, Quaternion.identity) as GameObject;
		levels = GameObject.Find("LevelController").GetComponent<levelController>();
		enemyNumber = 0;
		//maxEnemies = levels.level*5;
	}

	// Update is called once per frame
	void Update () {
        if (!enemyAlive && enemyNumber < maxEnemies)
        {
            StartCoroutine("spawn");
        }
        else if ((!enemyAlive && enemyNumber == maxEnemies) && levels.level == 1 && levelup)
        {
            levels.gameObject.SendMessage("nLevel");
            levelup = false;
        }
        else if (!enemyAlive && enemyNumber == maxEnemies)
        {
            StartCoroutine("spawnBoss");
        }
        else if (enemyAlive)
        {
            StopCoroutine("spawn");
            StopCoroutine("spawnBoss");
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
        newEnemy = Instantiate(enemies[(int)Math.Floor((double)UnityEngine.Random.Range(0, 3))], transform.position, Quaternion.identity) as GameObject;
        enemyNumber++;
	}

	IEnumerator spawnBoss() {
		yield return new WaitForSeconds(3.0f);
		GameObject.Find("Boss Path/BossPathStart").gameObject.SendMessage("spawner");
		enemyNumber ++;
		enemyIsAlive();
	}

	void speedUp () {
		speed += 0.5f;
	}

	void slowDown () {
		speed = 1f;
	}
}
