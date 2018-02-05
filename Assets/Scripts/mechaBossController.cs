using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechaBossController : MonoBehaviour {

    private Animator anim;
    //bool isWalking;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine("attacking");
	}

    IEnumerator attacking()
    {
        yield return new WaitForSeconds(3.0f);
        anim.SetBool("isWalking", true);
        //Debug.Log("true: " + isWalking);
        yield return new WaitForSeconds(3.0f);
        anim.SetBool("isWalking", false);
        //Debug.Log("false: " + isWalking);
        StopCoroutine("attacking");
    }
}
