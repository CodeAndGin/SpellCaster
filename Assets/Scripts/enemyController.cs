using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {
	public int health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
		health -= 1;
		other.gameObject.SendMessage("death");
	}

}
