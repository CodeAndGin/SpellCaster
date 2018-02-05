using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSpeedIncrease : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<enemyProjectileMove>().speed *= 1.025f;
    }
}
