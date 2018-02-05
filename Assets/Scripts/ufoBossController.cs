using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoBossController : MonoBehaviour {

	public float health = 6f;
	private levelController levels;
	private GameObject spawner;
	public GameObject projectilePrefab;
    private GameObject movingProjectile;
	public float fireRate = 8f;
    public AudioSource deathAudio;
    public AudioSource aliveNoise;
    bool playOnce = false;

	// Use this for initialization
	void Start () {
		spawner = GameObject.Find("EnemySpawner");
		StartCoroutine("fire");
		levels = GameObject.Find("LevelController").GetComponent<levelController>();
	}

	// Update is called once per frame
	void Update () {
		if (health < 1) death();
	}

	void damage() {
		fireRate /= 1.2f;
		GameObject.Find("Boss Path/BossPathStart").GetComponent<bossPath>().moveSpeed *= 1.2f;
		health -= 1f; //to be called by other scripts to damage the enemy
	}

	void OnTriggerEnter2D(Collider2D other) {
		other.gameObject.SendMessage("enemyInteraction", gameObject);	//tells whatever trigger touches it to do the "enemyInteraction" function
		if (other.gameObject.tag == "Projectile" || other.gameObject.tag == "Shield") other.gameObject.SendMessage("death"); //destroys Projectiles and shields
	}

	void death() {
        aliveNoise.Stop();
        if (playOnce == false)
        {
            deathAudio.volume = 0.5f;
            deathAudio.Play();
			playOnce = true;
        }
        Time.timeScale = 0;
		GameObject.Find("Boss Path/BossPathStart").GetComponent<bossPath>().moveSpeed = 0;
        StartCoroutine("deathSound");

	}

    IEnumerator deathSound()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        spawner.gameObject.SendMessage("enemyIsDead");
        Destroy(gameObject);
		GameObject.Find("Boss Path/BossPathStart").GetComponent<bossPath>().spawned = false;

		levels.gameObject.SendMessage("nLevel");

        StopCoroutine("deathSound");
    }

	void fireProjectile() {
		movingProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
	}

	IEnumerator fire() {
		while (true) {
			fireProjectile();
			yield return new WaitForSeconds(fireRate);
		}
	}
}
