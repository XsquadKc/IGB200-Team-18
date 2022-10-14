using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameESpawnObstacles : MonoBehaviour
{

    public GameObject obstacle;
    public GameObject canvasObject;

    public MGEGameManager playerDead;
    private GameObject manager;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    public float spawnTime;


    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManagerE");

        playerDead = manager.GetComponent<MGEGameManager>();
    }


    // Update is called once per frame
    void Update()
    {

        if (playerDead.playerDestroyed == false)
        {
            if (Time.time > spawnTime)
            {
                Spawn();
                spawnTime = Time.time + timeBetweenSpawn;
            }
        }

    }

    void Spawn()
    {

        // make screenbounds
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

       

        GameObject newObstacle = Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        newObstacle.transform.SetParent(canvasObject.transform, false);

       
    }
}
