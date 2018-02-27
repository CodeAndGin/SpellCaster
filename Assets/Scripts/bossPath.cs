using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bossPath : MonoBehaviour {

    private List<Vector3> waypoints;
    public GameObject enemyPreFab;
    private GameObject movingBoss;
    private int index;
    public float moveSpeed = 7f;


    public bool spawned = false;

    // Use this for initialization
    void Start () {
        waypoints = new List<Vector3>();



        for (int i = 0; i < transform.childCount; i++) //Loops through every child of the gameObject that the script is attached to. Then increments i by 1.
        {
            waypoints.Add(transform.GetChild(i).gameObject.transform.position); //Adds the Vector3 position of the child of index i.
        }
        waypoints.Add(transform.position); //Adds the parents position to the array.
        index = 0; //Sets the index to 0.
    }


// Update is called once per frame
    void Update()
    {
      if (spawned) {
        if (movingBoss.transform.position == waypoints[index]) //This checks whether the position of the enemy is equal to the current array index.
        {
            if (index == waypoints.Count - 1) //This checks whether the index variable is equal to 1 less than the array length
            {
                index = 0; //Sets index to 0
            }
            else
            {
                index++; //Increases index by 1.
            }
        }
        else
        {
            movingBoss.transform.position = Vector3.MoveTowards(movingBoss.transform.position, waypoints[index], moveSpeed * Time.deltaTime); //This makes the enemy move towards the current array index and sets the speed.
        }
      }
    }

    void spawner()
    {
      movingBoss = Instantiate(enemyPreFab, transform.position, Quaternion.identity) as GameObject;
      movingBoss.transform.position = gameObject.transform.position;
      spawned = true;
    }
}
