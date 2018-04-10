using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamPunkBossHeartController : MonoBehaviour {

	public GameObject[] hearts = new GameObject[20];
	float origHealth;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 20; i++) {
			string name = "health" + i;
			hearts[i] = GameObject.Find(name);
		}
		origHealth = gameObject.GetComponent<mechaBossController>().GetHealth();
	}

	// Update is called once per frame
	void Update () {
		DestroyHearts(gameObject.GetComponent<mechaBossController>().GetHealth());
	}

	void DestroyHearts(float health) {
		float percHealth = health / origHealth;
		for (int i = 0; i < 20; i++) {
			if (hearts[i] is GameObject && percHealth <= (float)i / 20) Destroy(hearts[i]);
		}
	}
}
