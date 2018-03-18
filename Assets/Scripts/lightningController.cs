using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		decay();
	}

	// Update is called once per frame
	void Update () {
	}

	void enemyInteraction(GameObject enemy) {
		enemy.gameObject.SendMessage("damage", 2f);
	}

	public void decay() {
		Destroy(gameObject, 1.0f);
	}

	void death () {
		Destroy(gameObject);
	}
}
