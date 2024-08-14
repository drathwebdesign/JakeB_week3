using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooseSpawner : MonoBehaviour
{
    public GameObject[] animals;
    public float spawnRangeX;
    public float spawnRangeZ;

    void Start()
    {
        
    }

    void Update()
    {
        spawnAnimal();
    }

    void spawnAnimal() { 
        if (Input.GetKeyDown(KeyCode.F)) {
            int randomIndex = Random.Range(0, animals.Length);
            Instantiate(animals[randomIndex], new Vector3 (Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ)), animals[randomIndex].transform.rotation);
        }
    }
}