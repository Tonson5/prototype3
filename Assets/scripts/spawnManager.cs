using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
   public GameObject obsticalPrefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    void Start()
    {
        InvokeRepeating("SpawnObstical", startDelay, repeatRate);
    }


    void SpawnObstical()
    {
        Instantiate(obsticalPrefab, spawnPosition, obsticalPrefab.transform.rotation);
    }
}
