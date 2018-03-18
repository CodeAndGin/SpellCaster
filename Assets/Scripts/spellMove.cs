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
	void Update () {
		rb.AddForce(transform.right*speed);
		if (transform.position.x > 25.0f) death();
	}

	void enemyInteraction(GameObject enemy) {
		enemy.gameObject.SendMessage("damage", damageDealt);
	}

	public void damage(int a) {
		death();
	}

	public void death() {
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
			//tells whatever trigger touches it to do the "playerInteraction" function
		if (other.gameObject.tag == "EnemyProjectile") {
			other.gameObject.SendMessage("playerInteraction", gameObject);
			other.gameObject.SendMessage("death"); //destroys Projectiles
		}
	}
}
