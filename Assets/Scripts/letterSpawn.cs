using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letterSpawn : MonoBehaviour {

	public GameObject controller;

	public gameStateController gameState;

	public int identity;

	private GameObject newLetter;
	public GameObject a;
	public GameObject b;
	public GameObject cee;
	public GameObject d;
	public GameObject e;
	public GameObject f;
	public GameObject g;
	public GameObject h;
	public GameObject i;
	public GameObject j;
	public GameObject k;
	public GameObject l;
	public GameObject m;
	public GameObject n;
	public GameObject o;
	public GameObject p;
	public GameObject q;
	public GameObject r;
	public GameObject s;
	public GameObject t;
	public GameObject u;
	public GameObject v;
	public GameObject w;
	public GameObject x;
	public GameObject y;
	public GameObject z;

	// Use this for initialization
	void Start () {
		gameState = GameObject.Find("GameStateController").GetComponent<gameStateController>();
	}

	// Update is called once per frame
	void Update () {
		if (!gameState.paused) {
			spawnLetter();
		}
	}

	bool checkIfActive () {
		if (controller.gameObject.GetComponent<TextController>().currentLetterSpawner == identity) {
			Debug.Log("I, number " + identity + " am the current letter");
			return true;
		} else {
			return false;
		}
	}

	void spawnLetter () {
		if (checkIfActive()) {
			foreach (char dee in Input.inputString) {
				string convert = "";
				convert = convert + dee;
				convert = convert.ToLower();
				char c = convert[0];
				/*
					The lines above just convert any capsLocked keys to lower case so the letters still
					spawn without issue. The same lines are in the TextController.cs script so that spells
					can still be cast no matter the arrangement of uppercase and lowercase letters in the
					typing variable
				*/
				if (c == 'a') {
					newLetter = Instantiate(a, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'b') {
					newLetter = Instantiate(b, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'c') {
					newLetter = Instantiate(cee, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'd') {
					newLetter = Instantiate(d, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'e') {
					newLetter = Instantiate(e, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'f') {
					newLetter = Instantiate(f, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'g') {
					newLetter = Instantiate(g, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'h') {
					newLetter = Instantiate(h, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'i') {
					newLetter = Instantiate(i, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'j') {
					newLetter = Instantiate(j, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'k') {
					newLetter = Instantiate(k, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'l') {
					newLetter = Instantiate(l, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'm') {
					newLetter = Instantiate(m, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'n') {
					newLetter = Instantiate(n, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'o') {
					newLetter = Instantiate(o, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'p') {
					newLetter = Instantiate(p, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'q') {
					newLetter = Instantiate(q, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'r') {
					newLetter = Instantiate(r, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 's') {
					newLetter = Instantiate(s, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 't') {
					newLetter = Instantiate(t, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'u') {
					newLetter = Instantiate(u, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'v') {
					newLetter = Instantiate(v, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'w') {
					newLetter = Instantiate(w, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'x') {
					newLetter = Instantiate(x, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'y') {
					newLetter = Instantiate(y, transform.position, Quaternion.identity) as GameObject;
				} else if (c == 'z') {
					newLetter = Instantiate(z, transform.position, Quaternion.identity) as GameObject;
				}
			}
		}
	}
}
