using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skip : MonoBehaviour {

    public void skipToEnd()
    {
        GameObject.Find("EnemySpawner").GetComponent<enemySpawner>().enemyNumber = GameObject.Find("EnemySpawner").GetComponent<enemySpawner>().maxEnemies;
    }    

}
