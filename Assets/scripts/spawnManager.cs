using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
   public GameObject obsticlePrefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private playerController playerControllerScript;
    
    void Start()
    {
        
        InvokeRepeating("SpawnObsticle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("player").GetComponent<playerController>();
    }


    void SpawnObsticle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obsticlePrefab, spawnPosition, obsticlePrefab.transform.rotation);
        }
       
    }
}
