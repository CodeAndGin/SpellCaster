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
		if (GetComponent<enemyController>() is enemyController) thisController = GetComponent<enemyController>();
	}

	// Update is called once per frame
	void Update () {

        if (isSlowed && !thisController.isFlashingRed)
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.color = new Color(0f, 0f, 0.8f, 1f);
        }
        else if (!thisController.isFlashingRed)
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.color = new Color(1f, 1f, 1f, 1f);
        }
	}

	void zapped () {
		if (!isStopped) StartCoroutine("Stopped");

	}

	IEnumerator Stopped () {
		float a = gameObject.GetComponent<enemyController>().GetSpeed();
		gameObject.SendMessage("SetSpeed", 0f);
		isStopped= true;
		yield return new WaitForSeconds(amountTimeShocked);
		gameObject.SendMessage("SetSpeed", a);
		isStopped = false;
		StopCoroutine("Stopped");
	}

	void icicleSlowDown () {
		if (!isSlowed) StartCoroutine("Slowed");

	}

	IEnumerator Slowed () {
		gameObject.SendMessage("MultSpeed", 0.5f);
		isSlowed = true;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(0f, 0f, 0.8f, 1f);
        yield return new WaitForSeconds(amountTimeSlowed);
		gameObject.SendMessage("MultSpeed", 2f);
		isSlowed = false;
        renderer.color = new Color(1f, 1f, 1f, 1f);
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
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1f, 0.6f, 0f, 1f);
        while (i < amountTimeBurned) {
			gameObject.SendMessage("damage", damagePerTick);
			i += tickFreq;
			yield return new WaitForSeconds(tickFreq);
		}
		isBurning = false;
        renderer.color = new Color(1f, 1f, 1f, 1f);
        StopCoroutine("Burning");
	}
}
