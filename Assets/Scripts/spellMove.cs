using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellMove : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		if (gameObject.tag == "Shield") decay();
	}

	// Update is called once per frame
	void Update () {
		// Vector2 movement = new Vector2 (1.0f, 0.0f);
		rb.AddForce(transform.right*speed);
		if (transform.position.x > 25.0f) death();
	}

	void enemyInteraction(GameObject enemy) {
		enemy.gameObject.SendMessage("damage");
	}

	public void death() {
		Destroy(gameObject);
	}

	public void decay() {
		Destroy(gameObject, 5.0f);
	}
}
