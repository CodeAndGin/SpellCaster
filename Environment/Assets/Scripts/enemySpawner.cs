using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

	public GameObject enemy;
	GameObject newEnemy;

	// Use this for initialization
	void Start () {
		newEnemy = Instantiate(enemy,transform.position,Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
