using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextController : MonoBehaviour {

	public GameObject fire;
	public GameObject ice;
	public GameObject lightning;
	public GameObject shield;
	public Text typing;

	private char enemyLetter;
	private char enemyLetterCaps;
	private GameObject spell;



	void Start () {
		typing = GameObject.Find("Text").GetComponent<Text>();
		typing.text = "";
	}

	void Update () {
		addToString();
		if (GameObject.Find("Enemy(Clone)") is GameObject) {
			enemyLetter = GameObject.Find("Enemy(Clone)").GetComponent<enemyName>().firstLetter;
			enemyLetterCaps = GameObject.Find("Enemy(Clone)").GetComponent<enemyName>().firstLetterAlt;
		}
	}

	void addToString() {
		foreach (char c in Input.inputString) {
			if (Input.GetKeyDown(KeyCode.Return)) {
				//castSpell();
				spells(typing.text);
				typing.text = "";
			} else if ((c != enemyLetter) && (c != enemyLetterCaps)){
				typing.text = typing.text + c;
			}
		}
	}

	void spells(string s) {
		if (s == "fireball" || s == "Fireball") {
			Debug.Log(typing.text);
			spell = Instantiate(fire, transform.position, Quaternion.identity) as GameObject;
		} else if (s == "icicle" || s == "Icicle") {
			spell = Instantiate(ice, transform.position, Quaternion.identity) as GameObject;
		} else if (s == "lightning" || s == "Lightning"){
			Vector3 pos = new Vector3(transform.position.x + 7.5f, transform.position.y, transform.position.z);
			spell = Instantiate(lightning, pos, Quaternion.identity) as GameObject;
		} else if (s == "shield" || s == "Shield") {
			spell = Instantiate(shield, transform.position, Quaternion.identity) as GameObject;
		} else {
			gameObject.SendMessage("death");
		}
	}
}
