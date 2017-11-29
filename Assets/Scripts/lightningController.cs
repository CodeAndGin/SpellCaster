using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningController : MonoBehaviour {

	private float timeTillDeath = 1.0f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		timeTillDeath -= Time.deltaTime;
		if (timeTillDeath <= 0.0f) death();
	}

	void enemyInteraction(GameObject enemy) {
		enemy.gameObject.SendMessage("damage");
	}

	public void death() {
		Destroy(gameObject);
	}
}
