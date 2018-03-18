using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3Jumper : MonoBehaviour
{

    public float thrust;
    public Rigidbody2D rb;
    public AudioSource jumpSound;
    private boss3Controller controller;

    // Use this for initialization
    void Start()
    {
        
        StartCoroutine("bossJump");

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("jump2");
        //StopCoroutine("bossJump");
    }

    IEnumerator bossJump()
    {
        while (true)
        {
            jumpSound.volume = 0.5f;
            jumpSound.Play();
            rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            yield return new WaitForSeconds(Random.Range(3f, 8f));
        }
    }

}
