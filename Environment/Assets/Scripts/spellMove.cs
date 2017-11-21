using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellMove : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// Vector2 movement = new Vector2 (1.0f, 0.0f);
		rb.AddForce(transform.right*speed);
	}

	public void death() {
		Destroy(gameObject);
	}
}
