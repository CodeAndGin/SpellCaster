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
	}

	// Update is called once per frame
	void Update () {

	}
}
