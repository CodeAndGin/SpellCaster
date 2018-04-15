using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nameCreator : MonoBehaviour {

	void MakeNewName (char first) {
		GameObject[] Letters = GameObject.FindGameObjectsWithTag("enemyNameLetter");
		foreach (GameObject letters in Letters) {
			GameObject.Destroy(letters);
		}
		for (int i = 0; i <= 5; i++) {
			transform.Find("BossNameLetterSpawner (" + i + ")").gameObject.SendMessage("createNewLetter", first);
		}
	}
}
