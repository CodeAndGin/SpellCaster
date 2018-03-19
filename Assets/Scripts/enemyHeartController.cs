using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHeartController : MonoBehaviour {

	public GameObject heart0;
	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (heart3 is GameObject && gameObject.GetComponent<enemyController>().GetHealth() <= 0.75) {
			Destroy(heart3);
		}
		if (heart2 is GameObject && gameObject.GetComponent<enemyController>().GetHealth() <= 0.5) {
			Destroy(heart2);
		}
		if (heart1 is GameObject && gameObject.GetComponent<enemyController>().GetHealth() <= 0.25) {
			Destroy(heart1);
		}
		if (heart0 is GameObject && gameObject.GetComponent<enemyController>().GetHealth() <= 0) {
			Destroy(heart0);
		}
	}
}
