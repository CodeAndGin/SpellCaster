using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectileMove : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector3 target = new Vector3(-12f, -5.5f, 110f);
		transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
	}

	public void death() {
		Destroy(gameObject);
	}

	public void playerInteraction(GameObject player) {
		player.gameObject.SendMessage("damage");
	}
}
