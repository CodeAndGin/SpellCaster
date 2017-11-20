using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextController : MonoBehaviour {

	public Text typing;

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
				typing.text = "";
				//castSpell();
			} else {
				typing.text = typing.text + c;
			}
		}
	}
}
