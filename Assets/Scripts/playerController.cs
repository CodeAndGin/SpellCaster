using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {
	public bool isShielded = false;
	//spells
	public GameObject fire;
	public GameObject ice;
	public GameObject lightning;
	public GameObject shield;
	private GameObject spell;

    public int hp;
    public GameObject heart;
    public GameObject newHeart;
    public AudioSource deathNoise;

	// Use this for initialization
	void Start () {
        hp = 4;
        hearts();
	}

	// Update is called once per frame
	void Update () {
        if (hp < 1){
            death();
        }
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

    void damage(){
		if (!isShielded) {
	        deathNoise.volume = 1;
	        deathNoise.Play();
	        hp -= 1;
	        Debug.Log("HEALTH: "+hp);
			Destroy(GameObject.Find("heart(Clone)"));
	        StartCoroutine("flashRed");
		}
    }

	void death() {
		StartCoroutine("Reset"); //Restarts the game
		Destroy(gameObject);	//kills the player
	}

    void hearts(){
        for (int i=0; i<hp; i++){
            newHeart = Instantiate(heart, new Vector3(-i+-10.5f,-3.0f,109.8f), Quaternion.identity) as GameObject;
        }
    }

	void castSpell (string s) {
		if (s == "fireball" || s == "Fireball") {
			spell = Instantiate(fire, transform.position, Quaternion.identity) as GameObject;
		} else if (s == "icicle" || s == "Icicle") {
			spell = Instantiate(ice, transform.position, ice.transform.rotation) as GameObject;
		} else if (s == "lightning" || s == "Lightning"){
			Vector3 pos = new Vector3(transform.position.x + 7.5f, transform.position.y, transform.position.z);
			spell = Instantiate(lightning, pos, Quaternion.identity) as GameObject;
		} else if (s == "shield" || s == "Shield") {
			if (GameObject.FindWithTag("playerShield") is GameObject) {
				GameObject.FindWithTag("playerShield").gameObject.SendMessage("powerUp");
			} else {
				spell = Instantiate(shield, transform.position, Quaternion.identity) as GameObject;
			}
		} else {
			Debug.Log("Not a match");
		}
		GameObject[] Letters = GameObject.FindGameObjectsWithTag("Letter"); //code adapted from user ZoogyBurger @ https://answers.unity.com/questions/1143629/destroy-multiple-gameobjects-with-tag-c.html
		foreach (GameObject letter in Letters) {
			GameObject.Destroy(letter);
		}
		GameObject.Find("LetterSpawnerController").gameObject.GetComponent<TextController>().currentLetterSpawner = 0;

	}

	void OnTriggerEnter2D(Collider2D other) {
			//tells whatever trigger touches it to do the "playerInteraction" function
		if (other.gameObject.tag == "EnemyProjectile") {
			other.gameObject.SendMessage("playerInteraction", gameObject);
			other.gameObject.SendMessage("death"); //destroys Projectiles
		}
	}

	IEnumerator Reset() {
		yield return new WaitForSeconds(3.0f);  //waits 3 seconds before the next line is called
        SceneManager.LoadScene(0);
	}

}
