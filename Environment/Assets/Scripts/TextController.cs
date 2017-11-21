using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextController : MonoBehaviour {

	public GameObject fire;
	public GameObject ice;
	public Text typing;
	GameObject spell;



	void Start () {
		typing = GameObject.Find("Text").GetComponent<Text>();
		typing.text = "";
	}
	
	void Update () {
		addToString();
	}
	
	void addToString() {
		foreach (char c in Input.inputString) {
			if (Input.GetKeyDown(KeyCode.Return)) {
				castSpell();
				typing.text = "";
			} else {
				typing.text = typing.text + c;
			}
		}
	}

	void castSpell() {
		switch (typing.text){
			default:
				//damageSelf();
				break;

			case "fireball":
				spells(typing.text);
				//Debug.Log(typing.text);
				break;

			case "icicle":
				spells(typing.text);
				//Debug.Log(typing.text);
				break;
		}
	}

	void spells(string s) {
		if (s == "fireball")
			spell = Instantiate(fire, transform.position, Quaternion.identity) as GameObject;

		if (s == "icicle")
			spell = Instantiate(ice, transform.position, Quaternion.identity) as GameObject;
	}
}
