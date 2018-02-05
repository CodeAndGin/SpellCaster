using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechaBossController : MonoBehaviour {

    private Animator anim;
    public GameObject projectilePrefab;
    private GameObject movingProjectile;
    public int health = 8;

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
        Vector3 fist = new Vector3(gameObject.transform.position.x - 3f, -5.11f, 163.1f);
        yield return new WaitForSeconds(3.0f);
        anim.SetBool("isWalking", true);
        transform.Translate(-Vector3.right * Time.deltaTime);
        yield return new WaitForSeconds(2f);
        anim.SetBool("isWalking", false);
        movingProjectile = Instantiate(projectilePrefab, fist, Quaternion.identity) as GameObject;
        StopCoroutine("attacking");
    }
}
