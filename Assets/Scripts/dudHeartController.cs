using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dudHeartController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void BaitandSwitch () {
		if (transform.Find("BossHeartsDUD") is Transform) {
			GameObject.Find("axe(Clone)").gameObject.SendMessage("EnableHearts");
			Destroy(transform.Find("BossHeartsDUD").gameObject);
		}
	}
}
