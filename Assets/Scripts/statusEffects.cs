using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusEffects : MonoBehaviour {

	enemyController thisController;

	//shock variables
	public float amountTimeShocked;
	bool isStopped = false;
	//ice variables
	public float amountTimeSlowed;
	bool isSlowed = false;

	//fire variables
	bool isBurning = false;
	public float amountTimeBurned;
	public float tickFreq;
	public float damagePerTick;

	// Use this for initialization
	void Start () {
		thisController = GetComponent<enemyController>();
	}

	// Update is called once per frame
	void Update () {

	}

	void zapped () {
		if (!isStopped) StartCoroutine("Stopped");

	}

	IEnumerator Stopped () {
		float a = thisController.speed;
		thisController.speed = 0;
		isStopped= true;
		yield return new WaitForSeconds(amountTimeShocked);
		thisController.speed = a;
		isStopped = false;
		StopCoroutine("Stopped");
	}

	void icicleSlowDown () {
		if (!isSlowed) StartCoroutine("Slowed");

	}

	IEnumerator Slowed () {
		thisController.speed *= 0.5f;
		isSlowed = true;
		yield return new WaitForSeconds(amountTimeSlowed);
		thisController.speed *= 2f;
		isSlowed = false;
		StopCoroutine("Slowed");
	}

	void fireballBurn () {
		if (!isBurning) {
			StartCoroutine("Burning");
		}
	}

	IEnumerator Burning () {
		isBurning = true;
		float i = 0;
		while (i < amountTimeBurned) {
			gameObject.SendMessage("damage", damagePerTick);
			i += tickFreq;
			yield return new WaitForSeconds(tickFreq);
		}
		isBurning = false;
		StopCoroutine("Burning");
	}
}
