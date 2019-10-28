using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject Unit;
    public int initialSpawnQuanitiy;


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

        for (int i = 0; i < initialSpawnQuanitiy; i++)
        {
            Instantiate(Unit, spawnPoints[i].position, Quaternion.identity);
        }
    }

}
