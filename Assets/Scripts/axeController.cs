using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeController : MonoBehaviour
{

    public float health;
    private GameObject boss3;

    // Use this for initialization
    

    void Update()
    {
        if (GameObject.FindWithTag("Miniboss") is GameObject)
        {
            boss3 = GameObject.FindWithTag("Miniboss");
        }
        if (health < 1) fall();
        if (transform.position.y < -30) death();
    }

    void damage()
    {
        health -= 1f; //to be called by other scripts to damage the enemy
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "EnemyProjectile") other.gameObject.SendMessage("enemyInteraction", gameObject);   //tells whatever trigger touches it to do the "enemyInteraction" function
        if (other.gameObject.tag == "Projectile" || other.gameObject.tag == "Shield") other.gameObject.SendMessage("death"); //destroys Projectiles and shields
    }

    void fall()
    {
        Collider2D boss3Coll = boss3.GetComponent<Collider2D>();
        Destroy(boss3Coll);
        Destroy(GetComponent<Collider2D>());
    }

    // Update is called once per frame

    void death()
    {
        Destroy(gameObject);
    }
}
