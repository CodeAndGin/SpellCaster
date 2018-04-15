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
		GameObject[] EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
		if (EnemyArray.Length > 0) {
			enemyLetter = EnemyArray[0].GetComponent<enemyName>().firstLetter;
			enemyLetterCaps = EnemyArray[0].GetComponent<enemyName>().firstLetterAlt;
		}
		// if (GameObject.FindWithTag("Enemy") is GameObject) {
		// 	enemyLetter = GameObject.FindWithTag("Enemy").GetComponent<enemyName>().firstLetter;
		// 	enemyLetterCaps = GameObject.FindWithTag("Enemy").GetComponent<enemyName>().firstLetterAlt;
		// }
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
			} else if (Input.GetKeyDown(KeyCode.Backspace)) {
				typing = "";
				deleteLetters();
			} else {
				string convert = "";
				convert = convert + c;
				convert = convert.ToLower();
				/*
					The lines above just convert any capsLocked keys to lower case so that spells
					can still be cast no matter the arrangement of uppercase and lowercase letters in the
					typing variable. The same lines are in the letterSpawn.cs script so that letters should
					spawn without fail
				*/
				typing = typing + convert;
				currentLetterSpawner++;
			}
		}
	}
//checks if enemy is immune or not and then casts spell or gives shield to enemy
	void checkSpellForEnemyBuff (string spell) {
		string letter = "";
		letter += enemyLetter;
		string letterBig = "";
		letterBig += enemyLetterCaps;
		//if (GameObject.FindWithTag("Enemy") is GameObject || GameObject.FindWithTag("Miniboss") is GameObject) {
			GameObject[] EnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
			if (EnemyArray.Length == 0 && GameObject.FindWithTag("Miniboss") is GameObject) {
				EnemyArray = GameObject.FindGameObjectsWithTag("Miniboss");
			}
			if (EnemyArray.Length > 0) {
				if ((spell.Contains(letter) || spell.Contains(letterBig)) && EnemyArray[0] is GameObject) {
					if (GameObject.FindWithTag("EnemyShield") is GameObject) {
						GameObject.FindWithTag("EnemyShield").gameObject.SendMessage("powerUp");
					} else EnemyArray[0].gameObject.SendMessage("shieldBuff");
					deleteLetters();
				}
				else {
					player.gameObject.SendMessage("castSpell", spell);
				}
			} else {
				player.gameObject.SendMessage("castSpell", spell);
			}
		//}

	}

	void deleteLetters () {
		GameObject[] Letters = GameObject.FindGameObjectsWithTag("Letter"); //code adapted from user ZoogyBurger @ https://answers.unity.com/questions/1143629/destroy-multiple-gameobjects-with-tag-c.html
		foreach (GameObject letters in Letters) {
			GameObject.Destroy(letters);
		}
		currentLetterSpawner = 0;
	}
}
