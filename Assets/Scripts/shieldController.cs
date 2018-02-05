using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldController : MonoBehaviour {

	public int health = 1;
	GameObject owner;

	void Start () {
		if (gameObject.tag == "playerShield") owner = GameObject.FindWithTag("Player");
		if (gameObject.tag == "EnemyShield") owner = GameObject.FindWithTag("Enemy");

		if (gameObject.tag == "playerShield") owner.GetComponent<playerController>().isShielded = true;
		if (gameObject.tag == "EnemyShield") owner.GetComponent<enemyController>().isShielded = true;
	}

	public void decay() {
		Destroy(gameObject, 5.0f);
	}

	void enemyInteraction(GameObject enemy) {
		enemy.gameObject.SendMessage("damage");
	}

	public void damage() {
		health--;
		if (health < 1) death();
	}

	public void death() {
		if (gameObject.tag == "playerShield") owner.GetComponent<playerController>().isShielded = false;
		if (gameObject.tag == "EnemyShield") owner.GetComponent<enemyController>().isShielded = false;
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (gameObject.tag == "playerShield" && other.gameObject.tag == "EnemyProjectile") {
			other.gameObject.SendMessage("death"); //destroys Projectiles
			damage();
		}
		if (gameObject.tag == "EnemyShield" && other.gameObject.tag == "Projectile") {
			other.gameObject.SendMessage("death"); //destroys Projectiles
			damage();
		}
	}

	void powerUp () {
		health++;
	}
}
