using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeController : MonoBehaviour
{

    public float health;
    private GameObject boss3;
    public AudioSource dmgSound;
    public GameObject shield;
    private GameObject shieldClone;

    // Use this for initialization
    public float GetHealth() {
		return health;
	}

    void shieldBuff () {
		shieldClone = Instantiate(shield, transform.position, Quaternion.identity);
		shieldClone.transform.parent = transform;
	}


    void Update()
    {
        if (GameObject.FindWithTag("Miniboss") is GameObject)
        {
            boss3 = GameObject.FindWithTag("Miniboss");
        }
        if (health < 0) fall();
        if (transform.position.y < -30) death();
    }

    void damage(float d)
    {
        dmgSound.volume = 0.5f;
        dmgSound.Play();
        //gameObject.SendMessage("BossRandomiseName");
        health -= d; //to be called by other scripts to damage the enemy
        StartCoroutine("flashRed");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "EnemyProjectile") other.gameObject.SendMessage("enemyInteraction", gameObject);   //tells whatever trigger touches it to do the "enemyInteraction" function
        if (other.gameObject.tag == "Projectile" || other.gameObject.tag == "Shield") {
            other.gameObject.SendMessage("death"); //destroys Projectiles and shields
            if (GameObject.Find("BossHeartsDUD") is GameObject) {
                GameObject.Find("boss3Walking").gameObject.SendMessage("BaitandSwitch");
            }
        }
    }

    void fall()
    {
        Collider2D boss3Coll = boss3.GetComponent<Collider2D>();
        Destroy(boss3Coll);
        Destroy(GetComponent<Collider2D>());
    }

    IEnumerator flashRed()
    {
        yield return new WaitForSeconds(0.0f);
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(0.8f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.3f);
        renderer.color = new Color(1f, 1f, 1f, 1f);
        StopCoroutine("flashRed");
    }

    // Update is called once per frame

    void death()
    {
        Destroy(gameObject);
    }
}
