﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldController : MonoBehaviour {

	public int health = 1;
	GameObject owner;

	void Start () {
		if (gameObject.tag == "playerShield") owner = GameObject.FindWithTag("Player");
		if (gameObject.tag == "EnemyShield" && GameObject.FindWithTag("Enemy") is GameObject) owner = GameObject.FindWithTag("Enemy");
		if (gameObject.tag == "EnemyShield" && GameObject.FindWithTag("Miniboss") is GameObject) owner = GameObject.FindWithTag("Miniboss");

		if (gameObject.tag == "playerShield") owner.GetComponent<playerController>().isShielded = true;
		if (gameObject.tag == "EnemyShield") owner.GetComponent<enemyController>().isShielded = true;
	}

    void Update()
    {
        if (gameObject.tag == "playerShield") GetComponent<SpriteRenderer>().color = new Color(86f/255f, 213f/255f, 1f, health/4f);
        if (gameObject.tag == "EnemyShield") GetComponent<SpriteRenderer>().color = new Color(255f / 255f, 86f / 255f, 86f/255f, health / 4f);
    }

	public void decay() {
		Destroy(gameObject, 5.0f);
	}

	void enemyInteraction(GameObject enemy) {
		if (owner.tag == "Player") enemy.gameObject.SendMessage("damage", 1f);
        if (gameObject.tag == "playerShield")  damage();
	}

	public void damage() {
        if (owner.tag == "Player") GameObject.FindWithTag("Player").gameObject.SendMessage("decreaseShield");
		health--;
		if (health < 1) death();
	}

	public void death() {
		if (gameObject.tag == "playerShield") owner.GetComponent<playerController>().isShielded = false;
		if (gameObject.tag == "EnemyShield" && GameObject.FindWithTag("Enemy") is GameObject) owner.GetComponent<enemyController>().isShielded = false;
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

		if  (gameObject.tag == "EnemyShield" && other.gameObject.tag == "Lightning") {
			damage();
			damage();
		}
	}

	void powerUp () {
        if (health < 3)
        {
            health++;
        }

	}
}
