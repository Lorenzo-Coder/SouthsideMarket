using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public
    public float howOften;
    public GameObject objectToSpawn;

    //Private
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        float timer = howOften;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            SpawnItem();
            timer = howOften;
        }
    }

    //Called when we need to spawn item
    void SpawnItem()
    { 
        int xPos = Random.Range(-9, 9);
        int yPos = (int)Mathf.Round(gameObject.transform.position.y);
        Instantiate(objectToSpawn, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }
}
