using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	public GameObject spawner;
	public GameObject eSpawner;
    public int hp;
    public GameObject heart;
    public GameObject newHeart;
	// Use this for initialization
	void Start () {
        hp = 4;
        hearts();
		spawner = GameObject.Find("PlayerSpawner");
		eSpawner = GameObject.Find("EnemySpawner");
		spawner.gameObject.SendMessage("playerIsAlive");
	}

	// Update is called once per frame
	void Update () {
        if (hp < 1){
            death();
        }
	}

    void damage(){
        hp -= 1;
        Debug.Log("HEALTH: "+hp);
		Destroy(GameObject.Find("heart(Clone)"));
    }

	void death() {
		spawner.gameObject.SendMessage("playerIsDead"); //tells the spawner that the player dies
		eSpawner.gameObject.SendMessage("slowDown"); //tell enemies to reset speed
		Destroy(gameObject);	//kills the player
	}

    void hearts(){
        for (int i=0; i<hp; i++){
            newHeart = Instantiate(heart, new Vector3(-i+-10.5f,-3.0f,109.8f), Quaternion.identity) as GameObject;
        }
    }

}
