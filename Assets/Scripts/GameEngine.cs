using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject Unit;


    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartSpawning()
    {

        for (int i = 0; i < 3; i++)
        {
            Instantiate(Unit, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
    }

}
