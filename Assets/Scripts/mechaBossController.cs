using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechaBossController : MonoBehaviour {

    private Animator anim;
    public int speed;
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
        transform.Translate(-Vector3.right * Time.deltaTime * speed);
        yield return new WaitForSeconds(2f);
        anim.SetBool("isWalking", false);
        StopCoroutine("attacking");
    }
}
