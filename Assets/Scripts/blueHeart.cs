using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueHeart : MonoBehaviour {

    Renderer rend;
    bool shielded = false;

	// Use this for initialization
	void Start () {
        rend = gameObject.GetComponent<Renderer>();
        rend.enabled = false;
    }
    
    // Update is called once per frame
    void Update () {
        shielded = transform.parent.transform.parent.gameObject.GetComponent<enemyController>().GetIsShielded();
        //Debug.Log(shielded);
        if (shielded == false)
        {
            rend.enabled = false;
        }
        else if(shielded == true)
        {
            rend.enabled = true;
        }
	}
}
