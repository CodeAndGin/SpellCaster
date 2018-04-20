using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public bool isShielded = false;
    //spells
    public GameObject fire;
    public GameObject fireball;
    public GameObject ice;
    public GameObject icicle;
    public GameObject lightning;
    public GameObject shield;
    private GameObject spell;
    private int shieldHP = 0;
    public GameObject [] blueHearts = new GameObject[3];

    public GameObject levels;
    public int hp;
    public GameObject heart;
    public GameObject newHeart;
    public AudioSource deathNoise;

    // Use this for initialization
    void Start()
    {
        hp = 4;
        hearts();
        levels = GameObject.Find("LevelController");
    }

    // Update is called once per frame
    void Update()
    {
        showBlueHearts();
        if (hp < 1)
        {
            death();
        }
    }

    public void decreaseShield()
    {
        shieldHP--;
    }

    void showBlueHearts()
    {
        if(shieldHP >= 1)
        {
            blueHearts[0].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            blueHearts[0].GetComponent<SpriteRenderer>().enabled = false;
        }
        if (shieldHP >= 2)
        {
            blueHearts[1].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            blueHearts[1].GetComponent<SpriteRenderer>().enabled = false;
        }
        if (shieldHP >= 3)
        {
            blueHearts[2].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            blueHearts[2].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator flashRed()
    {
        yield return new WaitForSeconds(0.0f);
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(0.8f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.3f);
        renderer.color = new Color(1f, 1f, 1f, 1f);
        StopCoroutine("flashRed");
    }

    void damage()
    {
        if (!isShielded)
        {
            deathNoise.volume = 1;
            deathNoise.Play();
            hp -= 1;
            Debug.Log("HEALTH: " + hp);
            Destroy(GameObject.Find("heart(Clone)"));
            GameObject.Find("EnemySpawner").gameObject.SendMessage("slowDown");
            StartCoroutine("flashRed");
        }
    }

    void death()
    {
        levels.gameObject.SendMessage("playerIsDead");
        Destroy(gameObject);    //kills the player
    }

    void hearts()
    {
        for (int i = 0; i < hp; i++)
        {
            newHeart = Instantiate(heart, new Vector3(-i + -10.5f, -2.28f, 109.8f), Quaternion.identity) as GameObject;
            newHeart.transform.parent = transform;
        }
    }

    void castSpell(string s)
    {
        Vector3 pos1 = new Vector3(-8.172113f, -5.097621f, 162);
        if (s == "fire")
        {
            spell = Instantiate(fire, pos1, ice.transform.rotation) as GameObject;
        }
        else if (s == "fireball")
        {
            spell = Instantiate(fireball, pos1, Quaternion.identity) as GameObject;
        }
        else if (s == "ice")
        {
            spell = Instantiate(ice, pos1, ice.transform.rotation) as GameObject;
        }
        else if (s == "icicle")
        {
            spell = Instantiate(icicle, pos1, ice.transform.rotation) as GameObject;
        }
        else if (s == "lightning")
        {
            Vector3 pos = new Vector3(transform.position.x + 6f, transform.position.y - 0.5f, transform.position.z);
            spell = Instantiate(lightning, pos, Quaternion.identity) as GameObject;
        }
        else if (s == "shield")
        {
            if (GameObject.FindWithTag("playerShield") is GameObject)
            {
                GameObject.FindWithTag("playerShield").gameObject.SendMessage("powerUp");
                if (shieldHP < 3)
                {
                    shieldHP++;
                }
            }
            else
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
                spell = Instantiate(shield, pos, Quaternion.identity) as GameObject;
                shieldHP = 1;
            }
        }
        else
        {
            Debug.Log("Not a match");
        }
        GameObject[] Letters = GameObject.FindGameObjectsWithTag("Letter"); //code adapted from user ZoogyBurger @ https://answers.unity.com/questions/1143629/destroy-multiple-gameobjects-with-tag-c.html
        foreach (GameObject letter in Letters)
        {
            GameObject.Destroy(letter);
        }
        GameObject.Find("LetterSpawnerController").gameObject.GetComponent<TextController>().currentLetterSpawner = 0;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //tells whatever trigger touches it to do the "playerInteraction" function
        if (other.gameObject.tag == "EnemyProjectile")
        {
            other.gameObject.SendMessage("playerInteraction", gameObject);
            other.gameObject.SendMessage("death"); //destroys Projectiles
        }
    }


}
