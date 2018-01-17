using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letterSpawn : MonoBehaviour {

	public GameObject controller;

	public int identity;

	private GameObject newLetter;
	public GameObject a;
	// public GameObject b;
	// public GameObject c;
	// public GameObject d;
	// public GameObject e;
	// public GameObject f;
	// public GameObject g;
	// public GameObject h;
	// public GameObject i;
	// public GameObject j;
	// public GameObject k;
	// public GameObject l;
	// public GameObject m;
	// public GameObject n;
	// public GameObject o;
	// public GameObject p;
	// public GameObject q;
	// public GameObject r;
	// public GameObject s;
	// public GameObject t;
	// public GameObject u;
	// public GameObject v;
	// public GameObject w;
	// public GameObject x;
	// public GameObject y;
	// public GameObject z;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		spawnLetter();
	}

	bool checkIfActive () {
		if (controller.gameObject.GetComponent<TextController>().currentLetterSpawner == identity) {
			return true;
		} else {
			return false;
		}
	}

	void spawnLetter () {
		if (checkIfActive()) {
			foreach (char c in Input.inputString) {
				if (c == 'a') {
					newLetter = Instantiate(a, transform.position, Quaternion.identity) as GameObject;
				}
			}
		}
	}
}
