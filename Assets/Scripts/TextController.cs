using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextController : MonoBehaviour {

	public gameStateController gameState;
	public string typing;	//string to compare with spells

	public int currentLetterSpawner = 0;

	private char enemyLetter;
	private char enemyLetterCaps;

	public GameObject player;
	private bool playerAlive;

	void Start () {
		gameState = GameObject.Find("GameStateController").GetComponent<gameStateController>();
		player = GameObject.FindWithTag("Player");
		typing = "";
	}

	void Update () {
		if (!gameState.paused) {
			checkForPlayer();
			addToString();
			checkEnemyName();
		}
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
				checkSpellForEnemyBuff(typing);
				typing = "";
			} else {
				typing = typing + c;
				currentLetterSpawner++;
			}
		}
	}

	void checkSpellForEnemyBuff (string spell) {
		string letter = "";
		letter += enemyLetter;
		string letterBig = "";
		letterBig += enemyLetterCaps;
		if ((spell.Contains(letter) || spell.Contains(letterBig)) && GameObject.FindWithTag("Enemy") is GameObject) {
			if (GameObject.FindWithTag("EnemyShield") is GameObject) {
				GameObject.FindWithTag("EnemyShield").gameObject.SendMessage("powerUp");
			} else GameObject.FindWithTag("Enemy").gameObject.SendMessage("shieldBuff");
			GameObject[] Letters = GameObject.FindGameObjectsWithTag("Letter"); //code adapted from user ZoogyBurger @ https://answers.unity.com/questions/1143629/destroy-multiple-gameobjects-with-tag-c.html
			foreach (GameObject letters in Letters) {
				GameObject.Destroy(letters);
			}
			currentLetterSpawner = 0;
		} else {
			player.gameObject.SendMessage("castSpell", spell);
		}
	}
}
