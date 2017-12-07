using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	public GameObject spawner;
	// Use this for initialization
	void Start () {
		spawner = GameObject.Find("PlayerSpawner");
		spawner.gameObject.SendMessage("playerIsAlive");
	}

	// Update is called once per frame
	void Update () {

	}

	void death() {
		spawner.gameObject.SendMessage("playerIsDead"); //tells the spawner that the player dies
		Destroy(gameObject);	//kills the player
	}

}
