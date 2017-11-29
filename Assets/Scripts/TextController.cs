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
				//castSpell();
				spells(typing.text);
				typing.text = "";
			} else {
				typing.text = typing.text + c;
			}
		}
	}
// Think this isn't really needed
	// void castSpell() {
	// 	switch (typing.text){
	// 		default:
	// 			gameObject.SendMessage("death");
	// 			break;
    //
	// 		case "fireball":
	// 			spells(typing.text);
	// 			//Debug.Log(typing.text);
	// 			break;
    //
	// 		case "Fireball":
	// 			spells(typing.text);
	// 			//Debug.Log(typing.text);
	// 			break;
    //
	// 		case "icicle":
	// 			spells(typing.text);
	// 			//Debug.Log(typing.text);
	// 			break;
    //
	// 		case "Icicle":
	// 			spells(typing.text);
	// 			//Debug.Log(typing.text);
	// 			break;
    //
	// 		case "lightning"
    //
    //
	// 	}
	// }

	void spells(string s) {
		if (s == "fireball" || s == "Fireball") {
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
