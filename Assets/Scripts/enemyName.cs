using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyName : MonoBehaviour {

	private ArrayList names;
	private string name;
	public char firstLetter;
	public char firstLetterAlt;

	private Text display;

	// Use this for initialization
	void Start () {

		display = GameObject.Find("enemyTitle").GetComponent<Text>();;
		names = new ArrayList();
		names.Add("Fiend");
		names.Add("Goblin");
		float rando = UnityEngine.Random.Range(0f, 1f);
		if (rando < 0.5) {
			rando = (float)Math.Floor(rando);
		} else {
			rando = (float)Math.Ceiling(rando);
		}
		int rand = (int)rando;
		name = (string)names[rand];
		firstLetterAlt = name[0];
		firstLetter = char.ToLower(firstLetterAlt);
		display.text = name;
	}

	// Update is called once per frame
	void Update () {

	}
}
