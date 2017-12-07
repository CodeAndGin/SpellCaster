using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {
	public float health;
	public int speed;
	//The rigidbody so we can move the enemy
	private Rigidbody2D rb;
	//So we can get the level number.
	private levelController levels;
	//To tell the spawner if the enemy had died
	private GameObject spawner;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		spawner = GameObject.Find("EnemySpawner");
		//Tells the spawner that there is an enemy active
		spawner.gameObject.SendMessage("enemyIsAlive");
		levels = GameObject.Find("LevelController").GetComponent<levelController>();
	}

	void Update () {
		if (health <= 0f) death(); //Kills the enemy if health is 0
		if (transform.position.x < -20) death(); //Kills the enemy if it leaves the left of the screen
		transform.Translate(-Vector3.right*Time.deltaTime*speed);	//moves the enemy
	}

	void damage() {
		health -= 1f; //to be called by other scripts to damage the enemy
	}

	void OnTriggerEnter2D(Collider2D other) {
		other.gameObject.SendMessage("enemyInteraction", gameObject);	//tells whatever trigger touches it to do the "enemyInteraction" function
		if (other.gameObject.tag == "Projectile" || other.gameObject.tag == "Shield") other.gameObject.SendMessage("death"); //destroys Projectiles and shields
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.SendMessage("death");	//sends message to player to die.
		}
	}

	void death() {
		spawner.gameObject.SendMessage("enemyIsDead");
		if (gameObject.tag == "Miniboss") {
			levels.gameObject.SendMessage("NextLevel");
		}
		Destroy(gameObject);
	}
}
