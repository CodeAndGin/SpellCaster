using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {
    public bool isFlashingRed = false;
	public bool isShielded = false;
	bool dying = false;
	GameObject shieldClone;
	public GameObject shield;
	public float health;
	public float speed;
	private float oldSpeed;
	//The rigidbody so we can move the enemy
	private Rigidbody2D rb;
	//So we can get the level number.
	private levelController levels;
	//To tell the spawner if the enemy had died
	private GameObject spawner;
    bool played = false;

	void Start () {
		health = 1;
		rb = GetComponent<Rigidbody2D>();
		spawner = GameObject.Find("EnemySpawner");

        health = spawner.GetComponent<enemySpawner>().health;
        speed = spawner.GetComponent<enemySpawner>().speed;
		//Tells the spawner that there is an enemy active
		spawner.gameObject.SendMessage("enemyIsAlive");
		levels = GameObject.Find("LevelController").GetComponent<levelController>();
	}

	void shieldBuff () {
		shieldClone = Instantiate(shield, transform.position, Quaternion.identity);
		shieldClone.transform.parent = transform;
	}

	void Update () {
		if (health <= 0f && !dying) death(); //Kills the enemy if health is 0
		if (transform.position.x < -20) death(); //Kills the enemy if it leaves the left of the screen
		transform.Translate(-Vector3.right*Time.deltaTime*speed);	//moves the enemy
	}

	void damage(float amount) {
		if (!isShielded) {
			health -= amount; //to be called by other scripts to damage the enemy
			StartCoroutine("flashRed");
		}
	}



	IEnumerator flashRed()
    {
        isFlashingRed = true;
        yield return new WaitForSeconds(0.0f);
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(0.8f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.3f);
        renderer.color = new Color(1f, 1f, 1f, 1f);
        isFlashingRed = false;
        StopCoroutine("flashRed");
    }

	public float GetHealth() {
		return health;
	}

    void OnTriggerEnter2D(Collider2D other) {
		other.gameObject.SendMessage("enemyInteraction", gameObject);	//tells whatever trigger touches it to do the "enemyInteraction" function
		if (other.gameObject.tag == "Projectile" || other.gameObject.tag == "Shield") other.gameObject.SendMessage("death"); //destroys Projectiles and shields
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
            other.gameObject.SendMessage("damage");	//sends message to player to die.
            //death();
            speed = 0;
            StartCoroutine("attack");
		}
		if (other.gameObject.tag == "Enemy") {
			oldSpeed = speed;
            speed = 0;
            //StartCoroutine("attack");
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.tag == "Enemy") {
			speed = oldSpeed;
		}
	}

	void death() {
		dying = true;
        speed = 0;

        if (played == false) {	//yeah so the sound is being played in death() and the death is happening in deathSound() dont ask pls;
            GetComponent<AudioSource>().volume = 0.5f;
            GetComponent<AudioSource>().Play();
            played = true;
        }
        StartCoroutine("deathSound");

	}

    IEnumerator deathSound()
    {
        yield return new WaitForSeconds(1.5f);
        spawner.gameObject.SendMessage("enemyIsDead");
        spawner.gameObject.SendMessage("speedUp");
        Destroy(gameObject);
        StopCoroutine("deathSound");
    }

    IEnumerator attack()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(2f);
            if (health <= 0)
            {
                StopCoroutine("attack");
            } else
            {
                GameObject.FindWithTag("Player").gameObject.SendMessage("damage");
            }
        }
        StopCoroutine("attack");
    }

	public float GetSpeed () {
		return speed;
	}

	void SetSpeed (float s) {
		speed = s;
	}

	void MultSpeed (float mult) {
		speed *= mult;
	}
}
