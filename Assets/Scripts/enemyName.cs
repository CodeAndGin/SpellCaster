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

	private char[] bossLetters;

	// Use this for initialization
	void Start () {
		bossLetters = new char[4];
		bossLetters[0] = 'l';
		bossLetters[1] = 'g';
		bossLetters[2] = 'c';
		bossLetters[3] = 'f';

		names = new ArrayList();
		names.Add("Fiend");
		names.Add("Goblin");
        names.Add("Chimera");
        if (firstLetter == 'f')
        {
            name = (string)names[0];
        } else if (firstLetter == 'g')
        {
            name = (string)names[1];
        }
        else if (firstLetter == 'c')
        {
            name = (string)names[2];
        }
		if (gameObject.tag == "Miniboss") {
			int index = UnityEngine.Random.Range(0,4);
			firstLetter = bossLetters[index];
			transform.Find("BossNameParent").gameObject.SendMessage("MakeNewName", firstLetter);
		}
	}

	// Update is called once per frame
	void Update () {

	}

	void BossRandomiseName() {
		int index = UnityEngine.Random.Range(0,4);
		firstLetter = bossLetters[index];

		transform.Find("BossNameParent").gameObject.SendMessage("MakeNewName", firstLetter);
	}
}
