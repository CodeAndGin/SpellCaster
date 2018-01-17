using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextController : MonoBehaviour {

	public string typing;	//string to compare with spells

	public int currentLetterSpawner = 0;

	private char enemyLetter;
	private char enemyLetterCaps;

	public GameObject player;
	private bool playerAlive;

	void Start () {
		player = GameObject.FindWithTag("Player");
		typing = "";
	}

	void Update () {
		checkForPlayer();
		addToString();
		checkEnemyName();
    }

	void checkForPlayer() {
		if (!playerAlive) {
			player = GameObject.FindWithTag("Player");
		}
		if (GameObject.FindWithTag("Player") is GameObject) {
			playerAlive = true;
		} else {
			playerAlive = false;
		}
	}

	void checkEnemyName() {
		if (GameObject.FindWithTag("Enemy") is GameObject) {
			enemyLetter = GameObject.FindWithTag("Enemy").GetComponent<enemyName>().firstLetter;
			enemyLetterCaps = GameObject.FindWithTag("Enemy").GetComponent<enemyName>().firstLetterAlt;
		}
        if (GameObject.FindWithTag("Miniboss") is GameObject)
        {
            enemyLetter = GameObject.FindWithTag("Miniboss").GetComponent<enemyName>().firstLetter;
            enemyLetterCaps = GameObject.FindWithTag("Miniboss").GetComponent<enemyName>().firstLetterAlt;
        }
	}

	void addToString() {
		foreach (char c in Input.inputString) {
			if (Input.GetKeyDown(KeyCode.Return)) {
				player.gameObject.SendMessage("castSpell", typing);
				typing = "";
			} else {
				typing = typing + c;
				currentLetterSpawner++;
			}
		}
	}
}
