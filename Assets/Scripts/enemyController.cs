using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {
	public float health;
	public int speed;
	private Rigidbody2D rb;

	private GameObject spawner;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		spawner = GameObject.Find("EnemySpawner");
		spawner.gameObject.SendMessage("enemyIsAlive");
		//speed = -1.0f;
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0f) death();
		if (transform.position.x < -20) death();
		rb.AddForce(-transform.right*speed);
	}

	void damage() {
		health -= 1f;
	}

	void OnTriggerEnter2D(Collider2D other) {
		other.gameObject.SendMessage("enemyInteraction", gameObject);
		if (other.gameObject.tag == "Projectile" || other.gameObject.tag == "Shield") other.gameObject.SendMessage("death");
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.SendMessage("death");
		}
	}

	void death() {
		spawner.gameObject.SendMessage("enemyIsDead");
		Destroy(gameObject);
	}
}
