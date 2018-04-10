using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechaBossController : MonoBehaviour {

    private Animator anim;
    public GameObject projectilePrefab;
    private GameObject movingProjectile;
    public float health;

    private GameObject spawner;
    private levelController levels;

    public AudioSource walkNoise;
    public AudioSource winningLine;
    public AudioSource deathAudio;
    bool playOnce = false;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

        spawner = GameObject.Find("EnemySpawner");
        levels = GameObject.Find("LevelController").GetComponent<levelController>();
        walkNoise.Play();
    }
    
    public float GetHealth() {
		return health;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SendMessage("enemyInteraction", gameObject);   //tells whatever trigger touches it to do the "enemyInteraction" function
        if (other.gameObject.tag == "Projectile" || other.gameObject.tag == "Shield") other.gameObject.SendMessage("death"); //destroys Projectiles and shields
    }

    // Update is called once per frame
    void Update () {
        StartCoroutine("attacking");

        if (health < 1) death();
	}

    IEnumerator attacking()
    {
        Vector3 fist = new Vector3(gameObject.transform.position.x - 3f, -5.11f, 163.1f);
        yield return new WaitForSeconds(3.0f);
        anim.SetBool("isWalking", true);
        walkNoise.UnPause();
        transform.Translate(-Vector3.right * Time.deltaTime);
        yield return new WaitForSeconds(2f);
        anim.SetBool("isWalking", false);
        walkNoise.Pause();
        movingProjectile = Instantiate(projectilePrefab, fist, Quaternion.identity) as GameObject;
        StopCoroutine("attacking");
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

    void death()
    {
        walkNoise.Stop();
        if (playOnce == false)
        {
            deathAudio.volume = 0.5f;
            deathAudio.Play();
            playOnce = true;
        }

        Time.timeScale = 0;
        StartCoroutine("deathSound");

    }

    void damage(float d)
    {
        health -= d; //to be called by other scripts to damage the enemy
        StartCoroutine("flashRed");
    }

    IEnumerator deathSound()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        spawner.gameObject.SendMessage("enemyIsDead");


        levels.gameObject.SendMessage("nLevel");
        Destroy(gameObject);

        StopCoroutine("deathSound");
    }
}
