using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBirb : MonoBehaviour
{

    //public GameObject birbPrefab;
    //private GameObject movingBirb;
    public float speed = 5f;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.right * speed);
        if (transform.position.x > 25.0f) death();
    }

    public void death()
    {
        Destroy(gameObject);
    }
}
