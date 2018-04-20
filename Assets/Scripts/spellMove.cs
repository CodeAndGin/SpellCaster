using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellMove : MonoBehaviour {

	public float speed;
	public float damageDealt;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce(transform.right*speed);
		if (transform.position.x > 25.0f) death();
	}

	void enemyInteraction(GameObject enemy) {
		if (gameObject.name == "Fireball" || gameObject.name == "Fireball(Clone)") {
			enemy.gameObject.SendMessage("fireballBurn");
			enemy.gameObject.SendMessage("damage", damageDealt);
            Debug.Log("Sent fireball dmg");
		} else if (gameObject.name == "Icicle" || gameObject.name == "Icicle(Clone)") {
			enemy.gameObject.SendMessage("icicleSlowDown");
			enemy.gameObject.SendMessage("damage", damageDealt);
            Debug.Log("Sent icicle dmg");
        } else {
			enemy.gameObject.SendMessage("damage", damageDealt);
		}

	}

	public void damage() {
		death();
	}

	public void death() {
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
			//tells whatever trigger touches it to do the "playerInteraction" function
		if (other.gameObject.tag == "EnemyProjectile") {
			Debug.Log ("Hit detected");
			other.gameObject.SendMessage("playerInteraction", gameObject);
			other.gameObject.SendMessage("death"); //destroys Projectiles
			death();
		}
	}
}
