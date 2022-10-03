using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectable : MonoBehaviour
{
    //These values are hardcoded by me seeing where I wanted the objects to spawn on my screen.
    //We should not hardcode these. We should see how big the camera is base those values off of this
    public GameObject lowestY;
    public GameObject highestY;

    //These are public variable because I will drag the gameobject into the variable spot using the Unity GUI
    public GameObject orangeCollectable;
    public GameObject pinkCollectable;
    public GameObject redCollectable;

    //random number to determine which collectable to spawn
    private int randomPrefab;

    //which collectable to spawn
    private GameObject spawnedCollectable;

    //used to calculate current time.
    private float time;
    //time to wait between spawning collectables
    public float delay;


    // Update is called once per frame
    void Update()
    {
        //add to time.  see how much time has passed since last frame
        time += Time.deltaTime;

        //I only want to spawn a new object if there was a specified amount of time between the last time I spawned an object
        if(time >= delay)
        {
            spawnObject();
            time = 0f;
        }
        
    }

    private void spawnObject()
    {
        //The max number on Random.Range in exlusive (up to not including)
        randomPrefab = Random.Range(0,3);

        if(randomPrefab == 0)
        {
            spawnedCollectable = Instantiate(orangeCollectable);
        }
        else if(randomPrefab == 1)
        {
            spawnedCollectable = Instantiate(pinkCollectable);
        }
        else if(randomPrefab == 2)
        {
            spawnedCollectable = Instantiate(redCollectable);
        }
        //spawn the gameobject a specific x and y position.  Y is random between two set values and x is set to be off screen so the objects move into view
        spawnedCollectable.transform.position = new Vector2(lowestY.transform.position.x, Random.Range(lowestY.transform.position.y, highestY.transform.position.y));
    }
}
