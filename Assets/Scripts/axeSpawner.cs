using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeSpawner : MonoBehaviour {

    public GameObject axePrefab;
    private GameObject axeTarget;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

    }

    void spawner()
    {
        axeTarget = Instantiate(axePrefab, transform.position, Quaternion.identity) as GameObject;
        axePrefab.transform.position = axeTarget.transform.position;
    }
}
