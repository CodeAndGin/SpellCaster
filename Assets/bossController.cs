using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour {

    public int health;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SendMessage("enemyInteraction", gameObject);   //tells whatever trigger touches it to do the "enemyInteraction" function
        if (other.gameObject.tag == "Projectile" || other.gameObject.tag == "Shield") other.gameObject.SendMessage("death"); //destroys Projectiles and shields
    }

    void damage()
    {
        health--;
    }

    void death()
    {


        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
