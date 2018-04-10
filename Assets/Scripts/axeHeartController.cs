using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeHeartController : MonoBehaviour {

	public GameObject[] hearts = new GameObject[20];
	float origHealth;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 20; i++) {
			string name = "health" + i;
			hearts[i] = transform.Find("BossHearts/" + name).gameObject;
		}
		origHealth = gameObject.GetComponent<axeController>().GetHealth();
	}

	// Update is called once per frame
	void Update () {
		DestroyHearts(gameObject.GetComponent<axeController>().GetHealth());
	}

	void DestroyHearts(float health) {
		float percHealth = health / origHealth;
		for (int i = 0; i < 20; i++) {
			if (hearts[i] is GameObject && percHealth <= (float)i / 20) Destroy(hearts[i]);
		}
	}

	public void EnableHearts() {
		for (int i = 0; i < 20; i++) {
			if (hearts[i] is GameObject) hearts[i].gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}
